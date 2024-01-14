using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinijuegoManagerBuscaIngredientes : MonoBehaviour
{
    public float timer, tiempoPerdidoPorFallar, tiempoGanadoPorAcertar;
    [SerializeField] private GameObject[] prefabIngrediente;
    [SerializeField] private GameObject canvasGameOver, canvasVictoria;
    [SerializeField] private int numeroDeNiveles, nivelFinal;
    [SerializeField] private int[] numeroDeObjetosPorNivel;
    [SerializeField] private int NumeroTotalDeIngredientes;
    [SerializeField] private float timerEspera;
    [SerializeField] private TMP_Text textNivel;
    public TMP_Text textTiempo;
    public GameObject objetoSuperpuesto;
    public float minimoValorEjeX, maximoValorEjeX, minimoValorEjeY, maximoValorEjeY;
    public bool timerEsperaEnabled = false, jugar = true, DestruirNivelEnabled = false;
    private float valorEjeX, valorEjeY;

    private int nivel = 0;
    public int Nivel { get { return nivel; } }

    private float timerInicio, timerEsperaInicial;

    private bool sonarVictoria = false;

    private int objeto;

    private static MinijuegoManagerBuscaIngredientes instance;
    public static MinijuegoManagerBuscaIngredientes Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    void Start()
    {
        //Seteamos todo para que esté listo para empezar y creamos el primer nivel

        timerInicio = timer;
        timerEsperaInicial = timerEspera;

        NumeroTotalDeIngredientes = NumeroTotalDeIngredientes - 1;

        CreadorNiveles();

        canvasGameOver.SetActive(false);

        canvasVictoria.SetActive(false);
    }

    void Update()
    {
        //Actualiza el HHUD en todo momento, además comprueba si hay que destruir el nivel o no.
        //También mira el temporizador y se comprueba si se ha ganado, perdido, o aún no había
        //pasado ninguna de las anteriores

        ActualizarHUD();
        DestructorNiveles();

        if (timer > 0 && jugar == true)
        {
            timer = timer - Time.deltaTime;
        }

        if (timer <= 0)
        {
            timer = 0;
            jugar = false;
            GamerOver();
        }

        if(nivel == nivelFinal)
        {
            Victoria();
        }
    }
    
    //Esta función es la encargada de crear niveles mediante los datos que se le pasan desde el inspector de Unity
    void CreadorNiveles()
    {
        objeto = 0;
        for (int i = numeroDeObjetosPorNivel[nivel]; i > 0; i--)
        {
            valorEjeX = Random.Range(minimoValorEjeX, maximoValorEjeX);
            valorEjeY = Random.Range(minimoValorEjeY, maximoValorEjeY);
            GameObject clon = Instantiate(prefabIngrediente[objeto]);
            if (objeto == 0)
            {
                clon.transform.position = new Vector3(valorEjeX, valorEjeY, -0.1f);
            }
            else
            {
                clon.transform.position = new Vector3(valorEjeX, valorEjeY, 0);
            }
            clon.GetComponent<IngredienteBuscaObjetos>().textTiempo = textTiempo;
            objeto = Random.Range(1, (NumeroTotalDeIngredientes + 1));
        }
    }

    // Esta función destruirá los objetos con los tags "Buscando" y "No buscando", y después llama a "CreadorNiveles"
    public void DestructorNiveles()
    {
        if (DestruirNivelEnabled == true)
        {
            jugar = false;

            GameObject[] objetosNoBuscar = GameObject.FindGameObjectsWithTag("No buscando");

            foreach (GameObject objeto in objetosNoBuscar)
            {
                Destroy(objeto);
            }

            if (timerEsperaEnabled == true)
            {
                timerEspera -= Time.deltaTime;
                if (timerEspera <= 0)
                {
                    timerEsperaEnabled = false;
                    timerEspera = timerEsperaInicial;

                    GameObject[] objetosABuscar = GameObject.FindGameObjectsWithTag("Buscando");

                    foreach (GameObject objeto in objetosABuscar)
                    {
                        Destroy(objeto);
                    }

                    nivel++;

                    CreadorNiveles();

                    DestruirNivelEnabled = false;
                    
                    jugar = true;
                }
            }
        }
    }

    void ActualizarHUD()
    {
        //Actualiza en el HUD el nivel en el que te encuentras
        textNivel.text = "Nivel: " + (nivel + 1).ToString("0");

        //Actualiza en el HUD el tiempo que te queda en cada momento
        textTiempo.text = "Tiempo: " + timer.ToString("0");
    }

    void GamerOver()
    {
        //Activa el canvas de Game Over
        canvasGameOver.SetActive(true);
    }

    public void Reintentar()
    {
        //Recarga la escena desde cero
        SceneManager.LoadScene("PulsarIngredientes");
    }

    void Victoria()
    {
        //Si se gana suena la música de victoria en el minijuego y se activa el canvas de victoria
        jugar = false;
        if(sonarVictoria == false)
        {
            GameManager.Instance.SonidoPlay(13);
            sonarVictoria = true;
        }

        canvasVictoria.SetActive(true);
    }

    public void CambiarEscena()
    {
        //Vuelve a la escena de pueblo
        SceneManager.LoadScene("Pueblo");
    }
}