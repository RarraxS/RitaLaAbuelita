using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject canvasDebug, canvasInicio, canvasControles;

    public string controles;
    public bool permitirAbrirMenuControles = true;

    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(this);

        canvasDebug.SetActive(false);
        canvasInicio.SetActive(true);
        canvasControles.SetActive(false);
    }

    void Update()
    {
        MenuDebug();
    }

    //Debug
    void MenuDebug()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)) && !canvasDebug.activeSelf)
        {
            canvasDebug.SetActive(true);
        }

        else if ((Input.GetKeyDown(KeyCode.Escape)) && canvasDebug.activeSelf)
        {
            canvasDebug.SetActive(false);
        }
    }

    public void TituloDebug()
    {
        canvasDebug.SetActive(false);
        SceneManager.LoadScene("Titulo");
    }

    public void MinijuegoPulsarIngredientesDebug()
    {
        canvasDebug.SetActive(false);
        SceneManager.LoadScene("PulsarIngredientes");
    }

    //Fin Debug

    public void Jugar()
    {
        SceneManager.LoadScene("Pueblo");
    }

    public void AbrirMenuControles()
    {
        canvasInicio.SetActive(false);
        canvasControles.SetActive(true);
    }

    void CerrarMenuControles()
    {
        canvasControles.SetActive(false);
        canvasInicio.SetActive(true);
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
}