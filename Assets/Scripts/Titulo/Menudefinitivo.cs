using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menudefinitivo : MonoBehaviour
{
    [SerializeField] GameObject canvasSonido;
    [SerializeField] GameObject canvasControles;
    [SerializeField] GameObject canvasPersonajes;
    [SerializeField] GameObject canvasSalir;


    // Start is called before the first frame update
    void Start()
    {
        canvasSonido.SetActive(true);
        canvasControles.SetActive(false);
        canvasPersonajes.SetActive(false);
        canvasSalir.SetActive(false);
    }
    public void Sonido()
    {
        canvasSonido.SetActive(true);
        canvasControles.SetActive(false);
        canvasPersonajes.SetActive(false);
        canvasSalir.SetActive(false);
    }
    public void Controles()
    {
        canvasSonido.SetActive(false);
        canvasControles.SetActive(true);
        canvasPersonajes.SetActive(false);
        canvasSalir.SetActive(false);
    }
    public void Personajes()
    {
        canvasSonido.SetActive(false);
        canvasControles.SetActive(false);
        canvasPersonajes.SetActive(true);
        canvasSalir.SetActive(false);
    }
     public void Salir()
    {
        canvasSonido.SetActive(false);
        canvasControles.SetActive(false);
        canvasPersonajes.SetActive(false);
        canvasSalir.SetActive(true);
    }
}
