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
        if ((Input.GetKey(KeyCode.I) && GameManager.controles == "zurdo") ||
            (Input.GetKey(KeyCode.W) && GameManager.controles == "diestro"))
        {
            rb.position += (Vector2)(Time.deltaTime * velocidad * transform.up);//Alante
        }

        if ((Input.GetKey(KeyCode.K) && GameManager.controles == "zurdo") ||
            (Input.GetKey(KeyCode.S) && GameManager.controles == "diestro"))
        {
            rb.position += (Vector2)(-transform.up * velocidad * Time.deltaTime);//Atrás
        }

        if ((Input.GetKey(KeyCode.J) && GameManager.controles == "zurdo") ||
            (Input.GetKey(KeyCode.A) && GameManager.controles == "diestro"))
        {
            rb.position += (Vector2)(-transform.right * velocidad * Time.deltaTime);//Izquierda
        }

        if ((Input.GetKey(KeyCode.L) && GameManager.controles == "zurdo") ||
            (Input.GetKey(KeyCode.D) && GameManager.controles == "diestro"))
        {
            rb.position += (Vector2)(transform.right * velocidad * Time.deltaTime);//Derecha
        }
    }
}
