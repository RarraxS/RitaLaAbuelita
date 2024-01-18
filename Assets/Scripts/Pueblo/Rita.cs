using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rita : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private GameObject canvasInteracciones, objetoNulo;
    public GameObject canvasDialogo;
    public GameObject rita;
    [SerializeField] private TMP_Text textInteraccion;

    private Vector3 direccion;
    private string tecla;
    public bool permitirMovimiento = true;
    private Scene currentScene;


    //Raycast
    public RaycastHit2D informacionRaycast;
    public float distanciaRaycast;
    [SerializeField] private LayerMask mascara;
    public Vector2 direccionRaycast = new Vector2(0, 1);

    //Animator
    [SerializeField] private Animator animator;
    //En el animator "Direccion" 1 es Alante, 2 es Derecha, 3 es Abajo, 4 es Izquierda


    private static Rita instance;
    public static Rita Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        //Inicializamos todo lo que vamos a necesitar
        if (GameManager.Instance.escena == "Pueblo")
        {
            ActualizarPosicion();
        }

        if (GameManager.Instance.escena == "CasaRita")
        {
            canvasInteracciones.SetActive(false);
        }

        canvasDialogo.SetActive(false);

        currentScene = GetComponent<Scene>();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Actualiza el Z Depth
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.y);
        transform.position = newPosition;


        Movimiento();
        LanzarRaycast();
        Interactuar();
        TextInteraccion();
    }

    void Movimiento()
    {
        //Dependiendo de que tecla pulse se mover� en una direcci�n u otra, y esto tiene sus propias animaciones

        direccion = Vector3.zero;

        if (permitirMovimiento == true)
        {
            if((((Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K)) || (Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.I)) ||
                (Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.L)) || (Input.GetKey(KeyCode.L) && !Input.GetKey(KeyCode.J))) && GameManager.Instance.controles == "zurdo") ||
                (((Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)) ||
                (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))) && GameManager.Instance.controles == "diestro"))
            {
                GameManager.Instance.SonidoPlay(1);
                animator.StopPlayback();
                animator.SetBool("Moviendose", true);
            }

            else if(!GameManager.Instance.canvasControles.activeSelf)
            {
                GameManager.Instance.SonidoStop();
                animator.SetBool("Moviendose", false);
            }

            if ((Input.GetKey(KeyCode.I) && GameManager.Instance.controles == "zurdo") ||
                (Input.GetKey(KeyCode.W) && GameManager.Instance.controles == "diestro"))
            {
                direccion += new Vector3(transform.up.x, transform.up.y); // Alante
                direccionRaycast = new Vector2(0, 1);
                animator.SetInteger("Direccion", 3);
            }

            if ((Input.GetKey(KeyCode.K) && GameManager.Instance.controles == "zurdo") ||
                (Input.GetKey(KeyCode.S) && GameManager.Instance.controles == "diestro"))
            {
                direccion += new Vector3(-transform.up.x, -transform.up.y); // Atr�s
                direccionRaycast = new Vector2(0, -1);
                animator.SetInteger("Direccion", 1);
            }

            if ((Input.GetKey(KeyCode.J) && GameManager.Instance.controles == "zurdo") ||
                (Input.GetKey(KeyCode.A) && GameManager.Instance.controles == "diestro"))
            {
                direccion += new Vector3(-transform.right.x, -transform.right.y); // Izquierda
                direccionRaycast = new Vector2(-1, 0);
                animator.SetInteger("Direccion", 4);
            }

            if ((Input.GetKey(KeyCode.L) && GameManager.Instance.controles == "zurdo") ||
                (Input.GetKey(KeyCode.D) && GameManager.Instance.controles == "diestro"))
            {
                direccion += new Vector3(transform.right.x, transform.right.y); // Derecha
                direccionRaycast = new Vector2(1, 0);
                animator.SetInteger("Direccion", 2);
            }
        }

        // Normalizar el vector de direcci�n si es diferente de cero
        if (direccion != Vector3.zero)
        {
            direccion.Normalize();
        }

        transform.position += (direccion * velocidad* Time.deltaTime);
    }

    void LanzarRaycast()
    {
        //Se usa un raycast para poder interactuar con los distintos objetos y NPC del juego

        // Realiza el raycast
        informacionRaycast = Physics2D.Raycast(transform.position, direccionRaycast, distanciaRaycast, mascara);

        // Dibuja el rayo en la escena para prop�sitos de depuraci�n
        Debug.DrawRay(transform.position, direccionRaycast * distanciaRaycast, Color.red);

        // Verifica si el raycast colision� con algo
        if (informacionRaycast.collider != null)
        {
            // Accede al GameObject con el que ha colisionado
            PuebloManager.Instance.collidedObject = informacionRaycast.collider.gameObject;
        }
        else
        {
            PuebloManager.Instance.collidedObject = objetoNulo;
        }

        // Imprime el nombre del GameObject por consola
        //Debug.Log(PuebloManager.Instance.collidedObject);
    }

    void Interactuar()
    {
        //Si se pulsa la tecla interacci�n y el raycast est� enfocando a un NPC
        //llama al "UiDialogo" que se encarga de gestionar los di�logos

        if (!Rita.Instance.canvasDialogo.activeSelf && Input.GetKeyDown(KeyCode.Space) && 
            PuebloManager.Instance.collidedObject.tag == "NPC")
        {
            canvasDialogo.SetActive(true);
            GameManager.Instance.SonidoStop();
            permitirMovimiento = false;
            UiDialogo.Instance.accesoInicial = false;
        }
    }

    void TextInteraccion()
    {
        //Si el raycast se choca con algo un texto con el bot�n que hay que pulsar para interactuar con el se hace visible
        if (PuebloManager.Instance.collidedObject.tag == "NPC" || PuebloManager.Instance.collidedObject.tag == "Casa")
        {
            canvasInteracciones.SetActive(true);
        }
        
        else if (!(PuebloManager.Instance.collidedObject.tag == "NPC" || PuebloManager.Instance.collidedObject.tag == "Casa"))
        {
            canvasInteracciones.SetActive(false);
        }

        if (GameManager.Instance.escena == "CasaRita")
        {
            canvasInteracciones.transform.SetParent(rita.transform);
        }
    }

    void ActualizarPosicion()
    {
        //Guarda la posici�n de Rita antes de cambiar de escena para que aparezca ah� cuando vuelva
        rita.transform.position = GameManager.Instance.position;
    }
}