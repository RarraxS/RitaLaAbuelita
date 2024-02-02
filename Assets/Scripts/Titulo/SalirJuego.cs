using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalirJuego : MonoBehaviour
{
    [SerializeField] GameObject canvasSalir;

    private void Start()
    {
        canvasSalir.SetActive(false);
    }
    public void PulsarSalir()
    {
        canvasSalir.SetActive(true);
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Quedarse()
    {
        canvasSalir.SetActive(false);
    }
}
