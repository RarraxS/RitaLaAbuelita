using UnityEngine;
using UnityEngine.SceneManagement;

public class GamOver_cocina : MonoBehaviour
{
    // Start is called before the first frame update
    public void PerderNivel1()
    {
        SceneManager.LoadScene("Cocinar1");
    }
    public void PerderNivel2()
    {
        SceneManager.LoadScene("Cocinar2");
    }
    public void PerderNivel3()
    {
        SceneManager.LoadScene("Cocinar3");
    }
    public void Pueblo()
    {
        Debug.Log("Cambio de escena");
        GameManager.Instance.escena = "CasaRita";
        SceneManager.LoadScene("CasaRita");
    }
}
