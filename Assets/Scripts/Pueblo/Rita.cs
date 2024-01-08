using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rita : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] GameObject canvasDialogo, canvasInteracciones, objetoNulo;
    public GameObject rita;
    [SerializeField] TMP_Text textInteraccion;

    private Rigidbody2D rb;
    string tecla;
    public bool permitirMovimiento = true;
    Scene currentScene;


    //Raycast
    public RaycastHit2D informacionRaycast;
    public float distanciaRaycast;
    [SerializeField] LayerMask mascara;
    public Vector2 direccionRaycast = new Vector2(0, 1);

    //Animator
    [SerializeField] Animator animator;
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
        ActualizarPosicion();

        canvasDialogo.SetActive(false);

        rb = GetComponent<Rigidbody2D>();

        currentScene = GetComponent<Scene>();

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movimiento();
        LanzarRaycast();
        Interactuar();
        TextInteraccion();
    }

    void Movimiento()
    {
        Vector2 direccion = Vector2.zero;

        if (permitirMovimiento == true)
        {
            if((((Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.K)) || (Input.GetKey(KeyCode.K) && !Input.GetKey(KeyCode.I)) ||
                (Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.L)) || (Input.GetKey(KeyCode.L) && !Input.GetKey(KeyCode.J))) && GameManager.Instance.controles == "zurdo") ||
                (((Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)) ||
                (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))) && GameManager.Instance.controles == "diestro"))
            {
                GameManager.Instance.SonidoPlay(1);
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
        // Realiza el raycast
        informacionRaycast = Physics2D.Raycast(transform.position, direccionRaycast, distanciaRaycast, mascara);

        // Dibuja el rayo en la escena para propósitos de depuración
        Debug.DrawRay(transform.position, direccionRaycast * distanciaRaycast, Color.red);

        // Verifica si el raycast colisionó con algo
        if (informacionRaycast.collider != null)
        {
            // Accede al GameObject con el que ha colisionado
            PuebloManager.Instance.collidedObject = informacionRaycast.collider.gameObject;
        }
        else
        {
            PuebloManager.Instance.collidedObject = objetoNulo ;
        }

        // Imprime el nombre del GameObject por consola
        Debug.Log(PuebloManager.Instance.collidedObject);
    }

    void Interactuar()
    {
        if (((Input.GetKeyDown(KeyCode.U) && GameManager.Instance.controles == "zurdo" && !canvasDialogo.activeInHierarchy) ||
            (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.controles == "diestro" && !canvasDialogo.activeInHierarchy)) && 
            PuebloManager.Instance.collidedObject.tag == "NPC")
        {
            canvasDialogo.SetActive(true);
            GameManager.Instance.SonidoStop();
            permitirMovimiento = false;
        }

        else if((Input.GetKeyDown(KeyCode.U) && GameManager.Instance.controles == "zurdo" && canvasDialogo.activeInHierarchy) || 
            (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.controles == "diestro" && canvasDialogo.activeInHierarchy))
        {
            canvasDialogo.SetActive(false);
            permitirMovimiento = true;
        }
    }

    void TextInteraccion()
    {
        if (PuebloManager.Instance.collidedObject.tag == "NPC")
        {
            if (GameManager.Instance.controles == "zurdo")
            {
                tecla = "U";
            }

            else
            {
                tecla = "E";
            }
        }

        if (PuebloManager.Instance.collidedObject.tag == "Casa")
        {
            tecla = "Espacio";
        }

        if (PuebloManager.Instance.collidedObject.tag == "NPC" || PuebloManager.Instance.collidedObject.tag == "Casa")
        {
            canvasInteracciones.SetActive(true);
            textInteraccion.text = "Pulsa: " + tecla;
        }
        
        else if (!(PuebloManager.Instance.collidedObject.tag == "NPC" || PuebloManager.Instance.collidedObject.tag == "Casa"))
        {
            canvasInteracciones.SetActive(false);
        }
    }

    void ActualizarPosicion()
    {
        rita.transform.position = GameManager.Instance.position;
    }
}