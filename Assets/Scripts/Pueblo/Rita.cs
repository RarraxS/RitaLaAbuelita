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
        if ((Input.GetKey(KeyCode.I) && GameManager.Instance.controles == "zurdo") ||
            (Input.GetKey(KeyCode.W) && GameManager.Instance.controles == "diestro"))
        {
            rb.position += (Vector2)(Time.deltaTime * velocidad * transform.up);//Alante
        }

        if ((Input.GetKey(KeyCode.K) && GameManager.Instance.controles == "zurdo") ||
            (Input.GetKey(KeyCode.S) && GameManager.Instance.controles == "diestro"))
        {
            rb.position += (Vector2)(-transform.up * velocidad * Time.deltaTime);//Atrás
        }

        if ((Input.GetKey(KeyCode.J) && GameManager.Instance.controles == "zurdo") ||
            (Input.GetKey(KeyCode.A) && GameManager.Instance.controles == "diestro"))
        {
            rb.position += (Vector2)(-transform.right * velocidad * Time.deltaTime);//Izquierda
        }

        if ((Input.GetKey(KeyCode.L) && GameManager.Instance.controles == "zurdo") ||
            (Input.GetKey(KeyCode.D) && GameManager.Instance.controles == "diestro"))
        {
            rb.position += (Vector2)(transform.right * velocidad * Time.deltaTime);//Derecha
        }
    }
}
