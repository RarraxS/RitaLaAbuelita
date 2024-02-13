using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaSalir : MonoBehaviour
{
    public void AbrirMenuPausa()
    {
        //Permite abrir el menú de pausa
        GameManager.Instance.canvasPausa.SetActive(true);
        MenuPausa.Instance.salida = false;

        if (GameManager.Instance.escena == "Titulo")
        {
            BotonesIntro.Instance.canvasInicio.SetActive(false);
        }

        if (GameManager.Instance.escena == "Pueblo" || GameManager.Instance.escena == "CasaRita")
        {
            Rita.Instance.permitirMovimiento = false;
        }

        if (GameManager.Instance.escena == "PulsarIngredientes")
        {
            MinijuegoManagerBuscaIngredientes.Instance.jugar = false;
        }

        if (GameManager.Instance.escena == "Quiz")
        {
            GameManager.Instance.canvasQuiz.SetActive(false);
        }
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
