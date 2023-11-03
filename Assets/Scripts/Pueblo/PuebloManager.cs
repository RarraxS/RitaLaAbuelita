using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuebloManager : MonoBehaviour
{
    [SerializeField] public GameObject canvasDebug, canvasControles;

    void Awake()
    {
        canvasDebug.SetActive(false);
    }

    void Start()
    {
        canvasControles.SetActive(true);
    }

    void Update()
    {
        MenuDebug();
    }

    public void MinijuegoPulsarIngredientes()
    {
        canvasDebug.SetActive(false);
        SceneManager.LoadScene("PulsarIngredientes");
    }

    void CerrarMenuControles()
    {
        canvasControles.SetActive(false);
    }

    public void botonDiestro()
    {
        GameManager.Instance.controles = "diestro";
        CerrarMenuControles();
    }

    public void botonZurdo()
    {
        GameManager.Instance.controles = "zurdo";
        CerrarMenuControles();
    }

    void MenuDebug()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)) && !canvasDebug.activeSelf)
        {
            canvasDebug.SetActive(true);
        }

        else if((Input.GetKeyDown(KeyCode.Escape)) && canvasDebug.activeSelf)
        {
            canvasDebug.SetActive(false);
        }
    }
}
