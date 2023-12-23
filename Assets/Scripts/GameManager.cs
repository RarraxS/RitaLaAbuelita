using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject canvasDebug, canvasInicio, canvasControles;

    public string escena, controles;
    public bool permitirAbrirMenuControles = true;

    [SerializeField] AudioClip[] Sonidos;

    public Toggle toggleZurdo, toggleDiestro;

    public AudioSource audioSourceMusica, audioSourceSonidos, audioSourceAmbienteSonidos;

    bool musica = true;

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


        Debug.Log("Les dedico este juego a Carlitos Martín, Mauricio Gavidia, Guilermo Pérez y Lola Fernandez");
    }

    void Update()
    {
        //MenuDebug();
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
        SonidoPlay(0);
        FondoInicio.Instance.animator.SetBool("Jugar", true);
        FondoInicio.Instance.timerActivado = true;
    }

    public void AbrirMenuControles()
    {
        canvasInicio.SetActive(false);
        SonidoPlay(0);
        canvasControles.SetActive(true);
    }

    public void CerrarMenuControles()
    {
        canvasControles.SetActive(false);
        canvasInicio.SetActive(true);
        SonidoPlay(0);
    }

    public void ToggleZurdo()
    {
        if (toggleZurdo.isOn)
        {
            //El toggle está activado
            controles = "zurdo";
            toggleDiestro.isOn = false;
            SonidoPlay(0);
        }
        else
        {
            //El toggle está desactivado
            controles = "diestro";
            toggleDiestro.isOn = true;
            SonidoPlay(0);
        }
    }

    public void ToggleDiestro()
    {
        if (toggleDiestro.isOn)
        {
            //El toggle está activado
            controles = "diestro";
            toggleZurdo.isOn = false;
            SonidoPlay(0);
        }
        else
        {
            //El toggle está desactivado
            controles = "zurdo";
            toggleZurdo.isOn = true;
            SonidoPlay(0);
        }
    }

   public void SonidoPlay(int num)
    {
        if(!audioSourceSonidos.isPlaying)
            audioSourceSonidos.PlayOneShot(Sonidos[num]);
    }

    public void SonidoStop()
    {
        if (audioSourceSonidos.isPlaying)
            audioSourceSonidos.Stop();
    }

    public void AmbientePlay(int num)
    {
        if (!audioSourceAmbienteSonidos.isPlaying)
            audioSourceAmbienteSonidos.PlayOneShot(Sonidos[num]);
    }

    public void AmbienteStop()
    {
        if (audioSourceAmbienteSonidos.isPlaying)
            audioSourceAmbienteSonidos.Stop();
    }

    public void SliderMusica(float valor)
    {
        audioSourceMusica.volume = valor;
    }

    public void SliderSonidos(float valor)
    {
        if (audioSourceMusica == true)
        {
            audioSourceSonidos.volume = valor;
            audioSourceAmbienteSonidos.volume = valor;
        }
        else
        {
            audioSourceSonidos.volume = 0;
            audioSourceAmbienteSonidos.volume = 0;
        }
        SonidoPlay(0);
    }
}