using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rita : MonoBehaviour
{
    [SerializeField] private float velocidad;

    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movimiento();
    }

    void Movimiento()
    {
        Vector2 direccion = Vector2.zero;

        if ((Input.GetKey(KeyCode.I) && GameManager.Instance.controles == "zurdo") ||
            (Input.GetKey(KeyCode.W) && GameManager.Instance.controles == "diestro"))
        {
            direccion += new Vector2(transform.up.x, transform.up.y); // Alante
        }

        if ((Input.GetKey(KeyCode.K) && GameManager.Instance.controles == "zurdo") ||
            (Input.GetKey(KeyCode.S) && GameManager.Instance.controles == "diestro"))
        {
            direccion += new Vector2(-transform.up.x, -transform.up.y); // Atr�s
        }

        if ((Input.GetKey(KeyCode.J) && GameManager.Instance.controles == "zurdo") ||
            (Input.GetKey(KeyCode.A) && GameManager.Instance.controles == "diestro"))
        {
            direccion += new Vector2(-transform.right.x, -transform.right.y); // Izquierda
        }

        if ((Input.GetKey(KeyCode.L) && GameManager.Instance.controles == "zurdo") ||
            (Input.GetKey(KeyCode.D) && GameManager.Instance.controles == "diestro"))
        {
            direccion += new Vector2(transform.right.x, transform.right.y); // Derecha
        }

        // Normalizar el vector de direcci�n si es diferente de cero
        if (direccion != Vector2.zero)
        {
            direccion.Normalize();
        }

        // Convertir la posici�n actual a Vector2 y aplicar la velocidad
        Vector2 nuevaPosicion = rb.position;
        nuevaPosicion += direccion * velocidad * Time.deltaTime;

        // Asignar la nueva posici�n al Rigidbody
        rb.position = nuevaPosicion;
    }

    void ApuntarConRaycast()
    {
        // Lanzar un rayo en la direcci�n del movimiento
        RaycastHit2D hit = Physics2D.Raycast(rb.position, rb.velocity.normalized);

        // Puedes realizar acciones basadas en la informaci�n del rayo, por ejemplo, imprimir el objeto golpeado
        if (hit.collider != null)
        {
            Debug.Log("Objeto golpeado: " + hit.collider.name);
        }

        // Aqu� puedes hacer m�s cosas con la informaci�n del rayo si es necesario
    }
}
