using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CocinaManager : MonoBehaviour
{
 
    //[SerializeField] GameObject Correcto1;
    //[SerializeField] GameObject Correcto2;
    //[SerializeField] GameObject Correcto3;
    //[SerializeField] GameObject Correcto4;

    //Atributos
    public int vidas = 3;

    //Canvas
    [SerializeField] GameObject canvasGameOver;
    [SerializeField] GameObject canvasWinGame;
    [SerializeField] GameObject Boton;

    void Start()
    {
        canvasGameOver.SetActive(false);
        canvasWinGame.SetActive(false);
        Boton.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void Cortar(Collider2D collision)
    //{
    //    if (collision.tag == "Correcto") //Que sucede con Correcto
    //    {
    //        //Animacion de cortar
    //        Debug.Log("Acertaste");
    //    }

    //    if (collision.tag == "Incorrecto") //Que sucede con Correcto
    //    {
    //        vidas--;
    //        Debug.Log("Fallaste");
    //    }
    //}

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Correcto1")) //Que sucede con Correcto
        {
            //Animacion de cortar
            Destroy(collision.gameObject);
            Debug.Log("Acertaste");
        }
        if (collision.gameObject.CompareTag("Correcto2")) //Que sucede con Correcto
        {
            //Animacion de cortar
            Destroy(collision.gameObject);
            Debug.Log("Acertaste");
        }
        if (collision.gameObject.CompareTag("Correcto3")) //Que sucede con Correcto
        {
            //Animacion de cortar
            Destroy(collision.gameObject);
            Debug.Log("Acertaste");
        }
        if (collision.gameObject.CompareTag("Correcto4")) //Que sucede con Correcto
        {
            //Animacion de cortar
            Destroy(collision.gameObject);
            Debug.Log("Acertaste");
        }

        if (collision.gameObject.CompareTag("Incorrecto1")) //Que sucede con Incorrecto
        {
            vidas--;
            Debug.Log("Fallaste");

            if (vidas <= 0)
            {
                Morir();
            }
        }
        if (collision.gameObject.CompareTag("Incorrecto2")) //Que sucede con Incorrecto
        {
            vidas--;
            Debug.Log("Fallaste");

            if (vidas <= 0)
            {
                Morir();
            }
        }
        if (collision.gameObject.CompareTag("Incorrecto3")) //Que sucede con Incorrecto
        {
            vidas--;
            Debug.Log("Fallaste");

            if (vidas <= 0)
            {
                Morir();
            }
        }
        if (collision.gameObject.CompareTag("Incorrecto4")) //Que sucede con Incorrecto
        {
            vidas--;
            Debug.Log("Fallaste");

            if (vidas <= 0)
            {
                Morir();
            }
        }
        if (collision.gameObject.CompareTag("Incorrecto5")) //Que sucede con Incorrecto
        {
            vidas--;
            Debug.Log("Fallaste");

            if (vidas <= 0)
            {
                Morir();
            }
        }
    }
    public void Morir()
    {
        if (vidas == 0)
        {
            canvasGameOver.SetActive(true);
            Boton.gameObject.SetActive(false);
        }
    }

}
