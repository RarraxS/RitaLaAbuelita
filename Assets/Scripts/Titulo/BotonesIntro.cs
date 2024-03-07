using UnityEngine;

public class BotonesIntro : MonoBehaviour
{
    [SerializeField] public GameObject canvasInicio;

    private static BotonesIntro instance;
    public static BotonesIntro Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        canvasInicio.SetActive(true);
    }

    public void Jugar()
    {
        //Cuando pulsas el botón en la pantalla de inicio suena el sonido y se reproduce la animación de la pantalla
        GameManager.Instance.reiniciando = false;
        canvasInicio.SetActive(false);
        GameManager.Instance.SonidoPlay(0);
        FondoInicio.Instance.animator.SetBool("Jugar", true);
        FondoInicio.Instance.timerActivado = true;
    }

    public void MenuControlesPausa()
    {
        GameManager.Instance.reiniciando = false;
        GameManager.Instance.AbrirMenuControles();
    }

    public void MenuSalirPausa()
    {
        SalirJuego.Instance.PulsarSalir();
    }
}
