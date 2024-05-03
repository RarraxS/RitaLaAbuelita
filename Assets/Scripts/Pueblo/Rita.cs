using UnityEngine;
using System.Collections;
using TMPro;

public class Rita : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private GameObject canvasInteracciones, objetoNulo;
    public GameObject canvasDialogo, rita, collidedObject;
    [SerializeField] private GameObject canvasTextoInteracion;
    [SerializeField] private TMP_Text textInteraccion;

    private Vector3 direccion;
    public bool permitirMovimiento = true;
    private Rigidbody2D rb;
    private Transform tr;
    [SerializeField] private GameObject textoCasa;
    [SerializeField] private TMP_Text textCasa;

   //Animator
   [SerializeField] private Animator animator;
    private bool parar, moviendose;
    private int direccionAnimator;
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
        tr = transform;

        if (GameManager.Instance.escena == "CasaRita")
        {
            textoCasa.SetActive(false);
        }

        //Inicializamos todo lo que vamos a necesitar
        if (GameManager.Instance.escena == "Pueblo" || GameManager.Instance.escena == "CasaRita")
        {
            ActualizarPosicion();
        }

        if (GameManager.Instance.escena == "CasaRita")
        {
            canvasTextoInteracion.SetActive(false);
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
        //tr.position = new Vector3(tr.position.x, tr.position.y, tr.position.y); 

        Movimiento();
        Interactuar();
        TextInteraccion();
    }
   
    
    //Es el update especializado para f�sicas
    private void FixedUpdate()
    {
        // Convertir la posici�n actual a Vector2 y aplicar la velocidad
        Vector2 nuevaPosicion = rb.position;
        nuevaPosicion += (Vector2)direccion * velocidad * Time.deltaTime;
        // Asignar la nueva posici�n al Rigidbody
        rb.position = (Vector2)nuevaPosicion;
    }

    private void OnAnimatorMove()
    {
        if (parar == true)
        {
            animator.StopPlayback();
            parar = false;
        }

        animator.SetBool("Moviendose", moviendose);
        
        animator.SetInteger("Direccion", direccionAnimator);
    }

    private void Movimiento()
    {
        //Dependiendo de que tecla pulse se mover� en una direcci�n u otra, y esto tiene sus propias animaciones

        direccion = Vector2.zero;

        if (permitirMovimiento == true)
        {
            if((((Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K)) || (Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.I)) ||
                (Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.L)) || (Input.GetKey(KeyCode.L) && !Input.GetKey(KeyCode.J))) && GameManager.Instance.controles == "zurdo") ||
                (((Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)) ||
                (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))) && GameManager.Instance.controles == "diestro"))
            {
                GameManager.Instance.SonidoPlay(1);
                parar = true;
                moviendose = true;
            }

            else if(!GameManager.Instance.canvasPausa.activeSelf)
            {
                GameManager.Instance.SonidoStop();
                moviendose = false;
            }

            if ((Input.GetKey(KeyCode.I) && GameManager.Instance.controles == "zurdo") ||
                (Input.GetKey(KeyCode.W) && GameManager.Instance.controles == "diestro"))
            {
                direccion += new Vector3(tr.up.x, tr.up.y, 0); // Adelante
                direccionAnimator = 3;
            }

            if ((Input.GetKey(KeyCode.K) && GameManager.Instance.controles == "zurdo") ||
                (Input.GetKey(KeyCode.S) && GameManager.Instance.controles == "diestro"))
            {
                direccion += new Vector3(-tr.up.x, -tr.up.y, 0); // Atr�s
                direccionAnimator = 1;
            }

            if ((Input.GetKey(KeyCode.J) && GameManager.Instance.controles == "zurdo") ||
                (Input.GetKey(KeyCode.A) && GameManager.Instance.controles == "diestro"))
            {
                direccion += new Vector3(-tr.right.x, -tr.right.y, 0); // Izquierda
                direccionAnimator = 4;
            }

            if ((Input.GetKey(KeyCode.L) && GameManager.Instance.controles == "zurdo") ||
                (Input.GetKey(KeyCode.D) && GameManager.Instance.controles == "diestro"))
            {
                direccion += new Vector3(tr.right.x, tr.right.y, 0); // Derecha
                direccionAnimator = 2;
            }
        }

        // Normalizar el vector de direcci�n si es diferente de cero
        if (direccion != Vector3.zero)
        {
            direccion.Normalize();
        }

    }
  
    private void TextInteraccion()
    {
        //Si el collider de Rita se choca con algo un texto con el bot�n que hay que pulsar para interactuar con el se hace visible
        if (((collidedObject.tag == "NPC" || collidedObject.tag == "Casa") ||
            (collidedObject.tag == "Cocinar" && 
            GameManager.Instance.quizCompletado == true && GameManager.Instance.buscaObjetosCompletado == true)) &&
            GameManager.Instance.escena == "Pueblo")
        {
            canvasInteracciones.SetActive(true);

            if (collidedObject.name == "Tono")
            {
                textInteraccion.text = "To�o";
            }

            else
            {
                textInteraccion.text = collidedObject.name.ToString();
            }
        }

        else if (!(collidedObject.tag == "NPC" || collidedObject.tag == "Casa") && GameManager.Instance.escena == "Pueblo")
        {
            canvasInteracciones.SetActive(false);
        }

        if (collidedObject.tag == "Busca objetos" && 
            (GameManager.Instance.quizCompletado == true && GameManager.Instance.buscaObjetosCompletado == false) 
            && GameManager.Instance.escena == "Pueblo")
        {
            canvasInteracciones.SetActive(true);
            textInteraccion.text = collidedObject.name.ToString();
        }

        if (GameManager.Instance.escena == "CasaRita" && 
            (collidedObject.tag == "Alfombra" || (collidedObject.tag == "Encimera" && GameManager.Instance.buscaObjetosCompletado == true)))
        {
            textoCasa.SetActive(true);
            textCasa.text = collidedObject.name.ToString();
        }

        if (GameManager.Instance.escena == "CasaRita" && collidedObject == objetoNulo)
        {
            textoCasa.SetActive(false);
        }
    }

    private void Interactuar()
    {
        //Si se pulsa la tecla interacci�n y el raycast est� enfocando a un NPC
        //llama al "UiDialogo" que se encarga de gestionar los di�logos

        if (GameManager.Instance.escena == "Pueblo")
        {
            if (!canvasDialogo.activeSelf && Input.GetKeyDown(KeyCode.Space) &&
                (collidedObject.tag == "NPC" || collidedObject.tag == "Quiz"))
            {
                moviendose = false;
                canvasDialogo.SetActive(true);
                GameManager.Instance.SonidoStop();
                permitirMovimiento = false;
                UiDialogo.Instance.accesoInicial = false;
            }
        }
    }

    private void ActualizarPosicion()
    {
        //Guarda la posici�n de Rita antes de cambiar de escena para que aparezca ah� cuando vuelva
        if (GameManager.Instance.escena == "Pueblo")
        {
            rita.transform.position = GameManager.Instance.posicionPueblo;
        }

        if (GameManager.Instance.escena == "CasaRita")
        {
            rita.transform.position = GameManager.Instance.posicionCasa;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el Rita ha colisionado con algo
        if (collision.gameObject.layer == 6)
        {
            // Accede al GameObject con el que ha colisionado
            collidedObject = collision.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Verifica si el Rita ha colisionado con algo
        if (collision.gameObject.layer == 6)
        {
            // Accede al GameObject con el que ha colisionado
            collidedObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collidedObject = objetoNulo;
    }
}