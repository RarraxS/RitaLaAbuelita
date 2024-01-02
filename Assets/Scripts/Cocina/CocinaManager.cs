using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CocinaManager : MonoBehaviour
{
    //Objeto principal
    [SerializeField] GameObject Cuchillo;

    //Objetos condicionales
    [SerializeField] GameObject Correcto1;
    [SerializeField] GameObject Correcto2;
    [SerializeField] GameObject Correcto3;
    [SerializeField] GameObject Correcto4;

    //Atributos
    public int vidas = 3;

    //Canvas
    [SerializeField] GameObject canvasGameOver;
    [SerializeField] GameObject canvasWinGame;
    [SerializeField] GameObject Boton;

    // Start is called before the first frame update
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

    public void Cortar(Collider2D collision)
    {
        if(collision)
        {
            //Animacion de cortar
            Debug.Log("Acertaste ");
        }
        else 
        {
            vidas--;
            Debug.Log("Acertaste ");
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
