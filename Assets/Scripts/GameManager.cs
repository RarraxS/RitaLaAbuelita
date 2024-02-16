using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject canvasPausa, canvasControles, canvasSalir, canvasQuiz;

    public string escena = "Titulo", controles;
    public bool permitirAbrirMenuControles = true, permitirTextIndicador = true;


    public Vector3 posicionPueblo, posicionCasa;
    private Vector3 posicionPuebloBase, posicionCasaBase;

    public bool buscaObjetosCompletado = false, quizCompletado = false;

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

        if (escena == "Pueblo")
        {
            posicionPueblo.z = posicionPueblo.y;
        }

        if (escena == "CasaRita")
        {
            posicionCasa.z = posicionCasa.y;
        }
        canvasControles.SetActive(false);
        canvasPausa.SetActive(false);

        //Lo inicializamos con controles de diestro
        toggleZurdo.isOn = false;

        posicionPuebloBase = posicionPueblo;
        posicionCasaBase = posicionCasa;
    }

    void Update()
    {
        //Guardamos en todo momento el nombre de la escena en la que nos encontramos
        
        PermitirMostrarIndicador();

        //-------------------------------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("PulsarIngredientes");
        //-------------------------------------------------------------------------------------
    }

    public void AbrirMenuControles()
    {
        //Cuando pulsas el bot�n controles suena un sonido y se pausan las distintas pruebas
        //de los minijuegos o el poder andar por el pueblo mientras el men� est� activo
        
        SonidoPlay(0);

        canvasControles.SetActive(true);
    }

    public void CerrarMenuControles()
    {
        //Este bot�n cierra el men� controles y lo devuelve todo a la normalidad 

        MenuControles.Instance.salidaControles = true;
        SonidoPlay(0);

        if (escena == "Titulo")
        {
            BotonesIntro.Instance.canvasInicio.SetActive(true);
        }
    }

    public void ToggleZurdo()
    {
        //Cambia los controles a zurdo y desactiva los de diestro cuando
        //esta activado y hace lo contrario cuando esta desactivado
        if (toggleZurdo.isOn)
        {
            //El toggle est� activado
            controles = "zurdo";
            toggleDiestro.isOn = false;
            SonidoPlay(0);
        }
        else
        {
            //El toggle est� desactivado
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
            //El toggle est� activado
            controles = "diestro";
            toggleZurdo.isOn = false;
            SonidoPlay(0);
        }
        else
        {
            //El toggle est� desactivado
            controles = "zurdo";
            toggleZurdo.isOn = true;
            SonidoPlay(0);
        }
    }

    private void PermitirMostrarIndicador()
    {
        if (escena == "Titulo" && canvasSalir.activeSelf)
        {
            permitirTextIndicador = false;
        }

        else
        {
            permitirTextIndicador = true;
        }
    }

   public void SonidoPlay(int num)
    {
        //Suena el sonido que se le pase por par�metro
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
        //Ajusta el volumen de la m�sica mediante un slider que controla el jugador
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