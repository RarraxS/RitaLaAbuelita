using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganar : MonoBehaviour
{
    // Start is called before the first frame update
    public void GanarCocina()
    {
        Debug.Log("Cambio de escena");
        GameManager.Instance.escena = "CasaRita";
        SceneManager.LoadScene("CasaRita");
    }
    public void Nivel2()
    {
        Debug.Log("Cambio de escena");
        SceneManager.LoadScene("Cocinar2");
    }
    public void Nivel3()
    {
        Debug.Log("Cambio de escena");
        SceneManager.LoadScene("Cocinar3");
    }

}
