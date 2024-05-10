using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganar : MonoBehaviour
{
    public void GanarCocina()
    {
        Debug.Log("Cambio de escena");
        GameManager.Instance.cocinarCompletado = true;
        GameManager.Instance.escena = "Victoria";
        SceneManager.LoadScene("PantallaCarga");
    }
    public void Nivel2()
    {
        Debug.Log("Cambio de escena");
        GameManager.Instance.escena = "Cocinar2";
        SceneManager.LoadScene("PantallaCarga");
    }
    public void Nivel3()
    {
        Debug.Log("Cambio de escena");
        GameManager.Instance.escena = "Cocinar3";
        SceneManager.LoadScene("PantallaCarga");
    }

}
