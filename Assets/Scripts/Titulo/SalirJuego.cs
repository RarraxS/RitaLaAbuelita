using UnityEngine;

public class SalirJuego : MonoBehaviour
{
    private static SalirJuego instance;
    public static SalirJuego Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

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
        MenuSalir.Instance.salidaSalir = true;
    }
}