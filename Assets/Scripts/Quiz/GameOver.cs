using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Perder()
    {
        GameManager.Instance.SonidoPlay(0);
        SceneManager.LoadScene("Quiz");
    }
    public void Ganar()
    {
        GameManager.Instance.SonidoPlay(0);
        Debug.Log("Cambio de escena");
        GameManager.Instance.quizCompletado = true;
        GameManager.Instance.escena = "Pueblo";
        SceneManager.LoadScene("PantallaCarga");
    }
    public void Pueblo()
    {
        GameManager.Instance.SonidoPlay(0);
        Debug.Log("Cambio de escena");
        GameManager.Instance.escena = "Pueblo";
        SceneManager.LoadScene("Pueblo");
    }
}
