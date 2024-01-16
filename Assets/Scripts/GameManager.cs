using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject canvasInicio, canvasControles, canvasQuiz;

    public string escena, controles;
    public bool permitirAbrirMenuControles = true;

    private string nombreEscenaActual;

    public Vector3 position;

    //Audio----------------------------------------------------------------------------------------------

    [SerializeField] private AudioClip[] Sonidos;

    public Toggle toggleZurdo, toggleDiestro;

    public AudioSource audioSourceMusica, audioSourceSonidos, audioSourceAmbienteSonidos;


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

        position.z = position.y;

        canvasInicio.SetActive(true);
        canvasControles.SetActive(false);

        //Lo inicializamos con controles de diestro
        toggleZurdo.isOn = false;
    }

    void Update()
    {
        //Guardamos en todo momento el nombre de la escena en la que nos encontramos
        nombreEscenaActual = SceneManager.GetActiveScene().name;
    }

    public void Jugar()
    {
        //Cuando pulsas el botón en la pantalla de inicio suena el sonido y se reproduce la animación de la pantalla
        canvasInicio.SetActive(false);
        SonidoPlay(0);
        FondoInicio.Instance.animator.SetBool("Jugar", true);
        FondoInicio.Instance.timerActivado = true;
    }

    public void AbrirMenuControles()
    {
        //Cuando pulsas el botón controles suena un sonido y se pausan las distintas pruebas
        //de los minijuegos o el poder andar por el pueblo mientras el menú está activo
        
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
        //Este botón cierra el menú controles y lo devuelve todo a la normalidad 

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
        //Cambia los controles a zurdo y desactiva los de diestro cuando
        //esta activado y hace lo contrario cuando esta desactivado
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
        //Cambia los controles a diestro y desactiva los de zurdo cuando
        //esta activado y hace lo contrario cuando esta desactivado
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
        //Suena el sonido que se le pase por parámetro
        if(!audioSourceSonidos.isPlaying)
            audioSourceSonidos.PlayOneShot(Sonidos[num]);
    }

    public void SonidoStop()
    {
        //Se paran los sonidos
        if (audioSourceSonidos.isPlaying)
            audioSourceSonidos.Stop();
    }

    public void AmbientePlay(int num)
    {
        //Suenan los sonidos de ambiente
        if (!audioSourceAmbienteSonidos.isPlaying)
            audioSourceAmbienteSonidos.PlayOneShot(Sonidos[num]);
    }

    public void AmbienteStop()
    {
        //Se paran los sonidos de ambiente 
        if (audioSourceAmbienteSonidos.isPlaying)
            audioSourceAmbienteSonidos.Stop();
    }

    public void SliderMusica(float valor)
    {
        //Ajusta el volumen de la música mediante un slider que controla el jugador
        audioSourceMusica.volume = valor;
    }

    public void SliderSonidos(float valor)
    {
        //Ajusta el volumen de todos los sonidos mediante un slider que controla el jugador
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