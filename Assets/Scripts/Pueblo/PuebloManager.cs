using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuebloManager : MonoBehaviour
{

    void Update()
    {
        CambioEscenaDemo();
    }

    void CambioEscenaDemo()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("PulsarIngredientes");
        }
    }
}
