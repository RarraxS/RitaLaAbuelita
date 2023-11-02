using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject canvasDebug, canvasControles;

    public static string controles;

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
            Destroy(this);

        DontDestroyOnLoad(this);
    }

    void Start()
    {
        canvasDebug.SetActive(false);
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
        controles = "diestro";
        CerrarMenuControles();
    }

    public void botonZurdo()
    {
        controles = "zurdo";
        CerrarMenuControles();
    }

    void MenuDebug()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            canvasDebug.SetActive(true);
        }
    }
}
