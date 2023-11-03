using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rita : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }
    void Movimiento()
    {
<<<<<<< HEAD:Assets/Scripts/Pueblo/Rita.cs
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
=======

>>>>>>> parent of f50ee36 (V 0.1):Assets/Scripts/Rita.cs
    }
}
