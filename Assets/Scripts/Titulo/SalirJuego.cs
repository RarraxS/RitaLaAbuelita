using UnityEngine;

public class SalirJuego : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.canvasSalir.SetActive(false);
    }
    public void PulsarSalir()
    {
        GameManager.Instance.canvasSalir.SetActive(true);
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Quedarse()
    {
        GameManager.Instance.canvasSalir.SetActive(false);
    }
}
