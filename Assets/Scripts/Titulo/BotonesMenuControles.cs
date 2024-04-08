using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonesMenuControles : MonoBehaviour
{
    [SerializeField] GameObject canvasSonido;
    [SerializeField] GameObject canvasControles;
    [SerializeField] GameObject canvasPersonajes;


    // Start is called before the first frame update
    void Start()
    {
        canvasControles.SetActive(true);
        canvasSonido.SetActive(false);
        canvasPersonajes.SetActive(false);
    }
    public void Sonido()
    {
        canvasControles.SetActive(false);
        canvasSonido.SetActive(true);
        canvasPersonajes.SetActive(false);
    }
    public void Controles()
    {
        canvasControles.SetActive(true);
        canvasSonido.SetActive(false);
        canvasPersonajes.SetActive(false);
    }
    public void Personajes()
    {
        canvasControles.SetActive(false);
        canvasSonido.SetActive(false);
        canvasPersonajes.SetActive(true);
    }
     public void Salir()
    {
        canvasControles.SetActive(false);
        canvasSonido.SetActive(false);
        canvasPersonajes.SetActive(false);
    }
}
