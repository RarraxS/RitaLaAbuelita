using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlesSalir : MonoBehaviour
{
    public void MenuControles()
    {
        //Permite abrir el menú de controles mediante un botón
        GameManager.Instance.AbrirMenuControles();
    }

    public void VolverPueblo()
    {
        //Permite salir del minijuego y volver al pueblo mediante un botón
        SceneManager.LoadScene("Pueblo");
    }
}
