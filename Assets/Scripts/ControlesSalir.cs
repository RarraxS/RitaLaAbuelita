using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlesSalir : MonoBehaviour
{
    public void MenuControles()
    {
        //Permite abrir el men� de controles mediante un bot�n
        GameManager.Instance.AbrirMenuControles();
    }

    public void VolverPueblo()
    {
        //Permite salir del minijuego y volver al pueblo mediante un bot�n
        SceneManager.LoadScene("Pueblo");
    }
}
