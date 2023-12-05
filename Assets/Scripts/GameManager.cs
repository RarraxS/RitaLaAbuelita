using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject canvasDebug, canvasInicio, canvasControles;

    public string controles;
    public bool permitirAbrirMenuControles = true;

    public Toggle toggleZurdo, toggleDiestro;

    public AudioSource audiosource;

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

        toggleZurdo.isOn = false;
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
        canvasInicio.SetActive(true);
        SceneManager.LoadScene("Titulo");
    }

    public void PuebloDebug()
    {
        canvasDebug.SetActive(false);
        canvasInicio.SetActive(false);
        SceneManager.LoadScene("Pueblo");
    }

    public void MinijuegoPulsarIngredientesDebug()
    {
        canvasDebug.SetActive(false);
        canvasInicio.SetActive(false);
        SceneManager.LoadScene("PulsarIngredientes");
    }

    public void MinijuegoPulsarQuizDebug()
    {
        canvasDebug.SetActive(false);
        canvasInicio.SetActive(false);
        SceneManager.LoadScene("Quiz");
    }

    //Fin Debug

    public void Jugar()
    {
        canvasInicio.SetActive(false);
        SceneManager.LoadScene("Pueblo");
    }

    public void AbrirMenuControles()
    {
        canvasInicio.SetActive(false);
        canvasControles.SetActive(true);
    }

    public void CerrarMenuControles()
    {
        canvasControles.SetActive(false);
        canvasInicio.SetActive(true);
    }

    public void ToggleZurdo()
    {
        if (toggleZurdo.isOn)
        {
            //El toggle está activado
            controles = "zurdo";
            toggleDiestro.isOn = false;
        }
        else
        {
            //El toggle está desactivado
            controles = "diestro";
            toggleDiestro.isOn = true;
        }
    }

    public void ToggleDiestro()
    {
        if (toggleDiestro.isOn)
        {
            //El toggle está activado
            controles = "diestro";
            toggleZurdo.isOn = false;
        }
        else
        {
            //El toggle está desactivado
            controles = "zurdo";
            toggleZurdo.isOn = true;
        }
    }

    public void SliderMusica()
    {
        audiosource.volume = 0.2f;
    }
}