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
        SceneManager.LoadScene("Pueblo");
    }
    public void Pueblo()
    {
        Debug.Log("Cambio de escena");
        SceneManager.LoadScene("Pueblo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}