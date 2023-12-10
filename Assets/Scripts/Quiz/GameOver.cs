using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public void Perder()
    {
        SceneManager.LoadScene("Quiz");
    }
    public void Ganar()
    {
        Debug.Log("Cambio de escena");
        SceneManager.LoadScene("Pueblo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
