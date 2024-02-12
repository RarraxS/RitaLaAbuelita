using UnityEngine;

public class Rita : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private GameObject canvasInteracciones, objetoNulo;
    public GameObject canvasDialogo, rita, collidedObject;

    private Vector3 direccion;
    public bool permitirMovimiento = true;
    private Rigidbody2D rb;


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
        if (GameManager.Instance.escena == "Pueblo" || GameManager.Instance.escena == "CasaRita")
        {
            ActualizarPosicion();
        }

        if (GameManager.Instance.escena == "CasaRita")
        {
            canvasInteracciones.SetActive(false);
        }

        if (GameManager.Instance.escena == "Pueblo")
        {
            canvasDialogo.SetActive(false);
        }

        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
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
        //Dependiendo de que tecla pulse se moverá en una dirección u otra, y esto tiene sus propias animaciones

        Vector2 direccion = Vector2.zero;

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

            else if(!GameManager.Instance.canvasPausa.activeSelf)
            {
                GameManager.Instance.SonidoStop();
                animator.SetBool("Moviendose", false);
            }

            if ((Input.GetKey(KeyCode.I) && GameManager.Instance.controles == "zurdo") ||
                (Input.GetKey(KeyCode.W) && GameManager.Instance.controles == "diestro"))
            {
                direccion += new Vector2(transform.up.x, transform.up.y); // Alante
                direccionRaycast = new Vector2(0, 1);
                animator.SetInteger("Direccion", 3);
            }

            if ((Input.GetKey(KeyCode.K) && GameManager.Instance.controles == "zurdo") ||
                (Input.GetKey(KeyCode.S) && GameManager.Instance.controles == "diestro"))
            {
                direccion += new Vector2(-transform.up.x, -transform.up.y); // Atrás
                direccionRaycast = new Vector2(0, -1);
                animator.SetInteger("Direccion", 1);
            }

            if ((Input.GetKey(KeyCode.J) && GameManager.Instance.controles == "zurdo") ||
                (Input.GetKey(KeyCode.A) && GameManager.Instance.controles == "diestro"))
            {
                direccion += new Vector2(-transform.right.x, -transform.right.y); // Izquierda
                direccionRaycast = new Vector2(-1, 0);
                animator.SetInteger("Direccion", 4);
            }

            if ((Input.GetKey(KeyCode.L) && GameManager.Instance.controles == "zurdo") ||
                (Input.GetKey(KeyCode.D) && GameManager.Instance.controles == "diestro"))
            {
                direccion += new Vector2(transform.right.x, transform.right.y); // Derecha
                direccionRaycast = new Vector2(1, 0);
                animator.SetInteger("Direccion", 2);
            }
        }

        // Normalizar el vector de dirección si es diferente de cero
        if (direccion != Vector2.zero)
        {
            direccion.Normalize();
        }

        // Convertir la posición actual a Vector2 y aplicar la velocidad
        Vector2 nuevaPosicion = rb.position;
        nuevaPosicion += direccion * velocidad * Time.deltaTime;

        // Asignar la nueva posición al Rigidbody
        rb.position = nuevaPosicion;
    }

    void LanzarRaycast()
    {
        //Se usa un raycast para poder interactuar con los distintos objetos y NPC del juego

        // Realiza el raycast
        informacionRaycast = Physics2D.Raycast(transform.position, direccionRaycast, distanciaRaycast, mascara);

        // Dibuja el rayo en la escena para propósitos de depuración
        Debug.DrawRay(transform.position, direccionRaycast * distanciaRaycast, Color.red);

        // Verifica si el raycast colisionó con algo
        if (informacionRaycast.collider != null)
        {
            // Accede al GameObject con el que ha colisionado
            collidedObject = informacionRaycast.collider.gameObject;
        }
        else
        {
            collidedObject = objetoNulo;
        }

        // Imprime el nombre del GameObject por consola
        //Debug.Log(PuebloManager.Instance.collidedObject);
    }

    void TextInteraccion()
    {
        //Si el raycast se choca con algo un texto con el botón que hay que pulsar para interactuar con el se hace visible
        if ((collidedObject.tag == "NPC" || collidedObject.tag == "Casa") ||
            (collidedObject.tag == "Busca objetos" && GameManager.Instance.quizCompletado == true && GameManager.Instance.buscaObjetosCompletado == false) ||
            (collidedObject.tag == "Quiz" && GameManager.Instance.quizCompletado == false) ||
            (collidedObject.tag == "Cocinar" && GameManager.Instance.quizCompletado == true && GameManager.Instance.buscaObjetosCompletado == true))
        {
            canvasInteracciones.SetActive(true);
        }

        else if (!(collidedObject.tag == "NPC" || collidedObject.tag == "Casa"))
        {
            canvasInteracciones.SetActive(false);
        }

        if (GameManager.Instance.escena == "CasaRita")
        {
            canvasInteracciones.transform.SetParent(rita.transform);
        }
    }

    void Interactuar()
    {
        //Si se pulsa la tecla interacción y el raycast está enfocando a un NPC
        //llama al "UiDialogo" que se encarga de gestionar los diálogos

        if (GameManager.Instance.escena == "Pueblo")
        {
            if (!Rita.Instance.canvasDialogo.activeSelf && Input.GetKeyDown(KeyCode.Space) &&
                collidedObject.tag == "NPC")
            {
                canvasDialogo.SetActive(true);
                GameManager.Instance.SonidoStop();
                permitirMovimiento = false;
                UiDialogo.Instance.accesoInicial = false;
            }
        }
    }

    void ActualizarPosicion()
    {
        //Guarda la posición de Rita antes de cambiar de escena para que aparezca ahí cuando vuelva
        if (GameManager.Instance.escena == "Pueblo")
        {
            rita.transform.position = GameManager.Instance.posicionPueblo;
        }

        if (GameManager.Instance.escena == "CasaRita")
        {
            rita.transform.position = GameManager.Instance.posicionCasa;
        }
    }
}