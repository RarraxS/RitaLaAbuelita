using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaSalir : MonoBehaviour
{
    public void MenuPausa()
    {
        //Permite abrir el menú de pausa
        GameManager.Instance.canvasPausa.SetActive(true);
    }

    public void VolverPueblo()
    {
        //Permite salir del minijuego y volver al pueblo mediante un botón
        GameManager.Instance.escena = "Pueblo";
        SceneManager.LoadScene("PantallaCarga");
    }
}
