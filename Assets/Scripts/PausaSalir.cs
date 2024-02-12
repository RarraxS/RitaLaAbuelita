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
        //Para las escenas de cocinar te saca a la casa de Rita
        if (GameManager.Instance.escena == "Cocinar1" || GameManager.Instance.escena == "Cocinar2" ||
            GameManager.Instance.escena == "Cocinar3")
        {
            GameManager.Instance.escena = "CasaRita";
            SceneManager.LoadScene("PantallaCarga");
        }

        //Para el resto de escenas te saca al pueblo
        else
        {
            //Permite salir del minijuego y volver al pueblo mediante un botón
            GameManager.Instance.escena = "Pueblo";
            SceneManager.LoadScene("PantallaCarga");
        }
    }
}
