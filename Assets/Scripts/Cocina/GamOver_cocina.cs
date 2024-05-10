using UnityEngine;
using UnityEngine.SceneManagement;

public class GamOver_cocina : MonoBehaviour
{
    // Start is called before the first frame update
    public void PerderNivel1()
    {
        GameManager.Instance.escena = "Cocinar1";
        SceneManager.LoadScene("PantallaCarga");
    }
    public void PerderNivel2()
    {
        GameManager.Instance.escena = "Cocinar2";
        SceneManager.LoadScene("PantallaCarga");
    }
    public void PerderNivel3()
    {
        GameManager.Instance.escena = "Cocinar3";
        SceneManager.LoadScene("PantallaCarga");
    }
    public void Pueblo()
    {
        Debug.Log("Cambio de escena");
        GameManager.Instance.escena = "Victoria";
        SceneManager.LoadScene("PantallaCarga");
    }
}
