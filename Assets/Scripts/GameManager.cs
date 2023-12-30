using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject canvasInicio, canvasControles, canvasQuiz;

    public string escena, controles;
    public bool permitirAbrirMenuControles = true;

    string nombreEscenaActual;

    //Audio----------------------------------------------------------------------------------------------

    [SerializeField] AudioClip[] Sonidos;

    public Toggle toggleZurdo, toggleDiestro;

    public AudioSource audioSourceMusica, audioSourceSonidos, audioSourceAmbienteSonidos;

    bool musica = true;

    //----------------------------------------------------------------------------------------------------

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

        canvasInicio.SetActive(true);
        canvasControles.SetActive(false);

        toggleZurdo.isOn = false;


        Debug.Log("Les dedico este juego a Carlitos Martín, Mauricio Gavidia, Guilermo Pérez y Lola Fernandez");
    }

    void Update()
    {
        nombreEscenaActual = SceneManager.GetActiveScene().name;
    }

    public void Jugar()
    {
        canvasInicio.SetActive(false);
        SonidoPlay(0);
        FondoInicio.Instance.animator.SetBool("Jugar", true);
        FondoInicio.Instance.timerActivado = true;
    }

    public void AbrirMenuControles()
    {
        SonidoPlay(0);
        
        if (nombreEscenaActual == "Titulo")
        {
            canvasInicio.SetActive(false);
        }

        if (nombreEscenaActual == "Pueblo")
        {
            Rita.Instance.permitirMovimiento = false;
        }

        if (nombreEscenaActual == "PulsarIngredientes")
        {
            MinijuegoManagerBuscaIngredientes.Instance.jugar = false;
        }

        if (nombreEscenaActual == "Quiz")
        {
            canvasQuiz.SetActive(false);
        }


        canvasControles.SetActive(true);
    }

    public void CerrarMenuControles()
    {
        canvasControles.SetActive(false);
        SonidoPlay(0);

        if (nombreEscenaActual == "Titulo")
        {
            canvasInicio.SetActive(true);
        }

        if (nombreEscenaActual == "Pueblo")
        {
            Rita.Instance.permitirMovimiento = true;
        }

        if (nombreEscenaActual == "PulsarIngredientes")
        {
            MinijuegoManagerBuscaIngredientes.Instance.jugar = true;
        }

        if (nombreEscenaActual == "Quiz")
        {
            canvasQuiz.SetActive(true);
        }
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