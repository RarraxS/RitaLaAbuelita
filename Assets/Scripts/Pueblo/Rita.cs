using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;

public class Rita : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] ScriptableObject[] interaccion;
    [SerializeField] GameObject canvasDialogo;
    [SerializeField] TMP_Text textRita, textNpc;

    GameObject collidedObject;

    private Rigidbody2D rb;
    Animator animator;

    //Raycast
    RaycastHit2D informacionRaycast;
    public float distanciaRaycast;
    [SerializeField] LayerMask mascara;
    public Vector2 direccionRaycast = new Vector2(0, 1);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        canvasDialogo.SetActive(false);
    }

    void Update()
    {
        Movimiento();
        LanzarRaycast();
        AccederInteractuable();
        Interactuar();
    }

    void Movimiento()
    {
        Vector2 direccion = Vector2.zero;

        if ((Input.GetKey(KeyCode.I) && GameManager.Instance.controles == "zurdo") ||
            (Input.GetKey(KeyCode.W) && GameManager.Instance.controles == "diestro"))
        {
            direccion += new Vector2(transform.up.x, transform.up.y); // Alante
            direccionRaycast = new Vector2(0, 1);
        }

        if ((Input.GetKey(KeyCode.K) && GameManager.Instance.controles == "zurdo") ||
            (Input.GetKey(KeyCode.S) && GameManager.Instance.controles == "diestro"))
        {
            direccion += new Vector2(-transform.up.x, -transform.up.y); // Atrás
            direccionRaycast = new Vector2(0, -1);
        }

        if ((Input.GetKey(KeyCode.J) && GameManager.Instance.controles == "zurdo") ||
            (Input.GetKey(KeyCode.A) && GameManager.Instance.controles == "diestro"))
        {
            direccion += new Vector2(-transform.right.x, -transform.right.y); // Izquierda
            direccionRaycast = new Vector2(-1, 0);
        }

        if ((Input.GetKey(KeyCode.L) && GameManager.Instance.controles == "zurdo") ||
            (Input.GetKey(KeyCode.D) && GameManager.Instance.controles == "diestro"))
        {
            direccion += new Vector2(transform.right.x, transform.right.y); // Derecha
            direccionRaycast = new Vector2(1, 0);
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
            collidedObject = informacionRaycast.collider.gameObject;
        }
        else
        {
            collidedObject = null;
        }

        // Imprime el nombre del GameObject por consola
        Debug.Log(collidedObject);
    }

    void AccederInteractuable()
    {
        for (int i = 0; i < interaccion.Length; i++)
        {
            if (collidedObject.name == interaccion[i].name)
            {
                string DialogoNpc = ((DialogoNpc)interaccion[i]).dialogoNpc;
                string DialogoRita = ((DialogoNpc)interaccion[i]).dialogoRita;
                int numNpc = ((DialogoNpc)interaccion[i]).numNpc;

                textNpc.text = DialogoNpc;
                textRita.text = DialogoRita;
                //animator.SetInteger("npc", numNpc);
            }
        }
    }


    void Interactuar()
    {
        if(Input.GetKeyDown(KeyCode.U) && !canvasDialogo.activeSelf)
        {
            canvasDialogo.SetActive(true);
        }

        else if(Input.GetKeyDown(KeyCode.U) && canvasDialogo.activeSelf)
        {
            canvasDialogo.SetActive(false);
            animator.SetInteger("npc", 0);
            Debug.Log("None");
        }
    }
}
