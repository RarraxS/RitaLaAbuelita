using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuebloManager : MonoBehaviour
{
    public GameObject collidedObject;

    private static PuebloManager instance;
    public static PuebloManager Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        CambioEscenaDemo();
    }

    void CambioEscenaDemo()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("PulsarIngredientes");
            GameManager.Instance.SonidoStop();
        }
    }
}
