using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuebloManager : MonoBehaviour
{
    public GameObject collidedObject, cambioBuscaObjetos;

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
        CmabioBuscaObjetos();
    }

    void CmabioBuscaObjetos()
    {
        if (PuebloManager.Instance.collidedObject == PuebloManager.Instance.cambioBuscaObjetos && Input.GetKey(KeyCode.Space))
        {
            GameManager.Instance.escena = "PulsarIngredientes";
            SceneManager.LoadScene("PantallaCarga");
        }
    }
}