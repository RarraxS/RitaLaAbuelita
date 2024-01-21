using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamOver_cocina : MonoBehaviour
{
    // Start is called before the first frame update
    public void Perder()
    {
        SceneManager.LoadScene("Cocinar");
    }
    public void Ganar()
    {
        Debug.Log("Cambio de escena");
        GameManager.Instance.escena = "CasaRita";
        SceneManager.LoadScene("CasaRita");
    }
    public void Nivel2()
    {
        Debug.Log("Cambio de escena");
        SceneManager.LoadScene("Cocinar 2");
    }
    public void Nivel3()
    {
        Debug.Log("Cambio de escena");
        SceneManager.LoadScene("Cocinar 3");
    }
    public void Pueblo()
    {
        Debug.Log("Cambio de escena");
        GameManager.Instance.escena = "CasaRita";
        SceneManager.LoadScene("CasaRita");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
