using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Perder()
    {
        SceneManager.LoadScene("Quiz");
    }
    public void Ganar()
    {
        Debug.Log("Cambio de escena");
        GameManager.Instance.quizCompletado = true;
        GameManager.Instance.escena = "Pueblo";
        SceneManager.LoadScene("PantallaCarga");
    }
    public void Pueblo()
    {
        Debug.Log("Cambio de escena");
        GameManager.Instance.escena = "Pueblo";
        SceneManager.LoadScene("Pueblo");
    }
}
