using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

[RequireComponent(typeof(AudioSource))]
public class QuizManager : MonoBehaviour
{
    [SerializeField] private Color colorcorrecto = Color.black;
    [SerializeField] private Color colorincorrecto = Color.black;

    [SerializeField] public int vidas = 1;

    public bool preguntacorrecta = true;
    public bool preguntaincorrecta = false;

    [SerializeField] GameObject canvasGameOver;
    [SerializeField] GameObject Reiniciar;
    [SerializeField] GameObject canvasWinGame;
    [SerializeField] GameObject Continuar;

    public int VolverAlPueblo = 0;
    public TMP_Text textoContador;

    private Quiz quizDB = null;
    private QuizUI quizUI = null;
    private AudioSource quizAudioSource = null;


    bool permitirTemp = false;
    float temp = 1f;

    private bool sonarVictoria = false;


    private void Start()
    {
        quizDB = GameObject.FindObjectOfType<Quiz>();
        quizUI = GameObject.FindObjectOfType<QuizUI>();
        quizAudioSource = GetComponent<AudioSource>();
        canvasGameOver.SetActive(false);
        Reiniciar.gameObject.SetActive(false);
        canvasWinGame.SetActive(false);
        Continuar.gameObject.SetActive(false);
        NextQuestion();
    }

    void Update()
    {
        if (permitirTemp == true)
        {
            temp -= Time.deltaTime;

            if (temp <= 0)
            {
                permitirTemp = false;
                temp = 1f;
                NextQuestion();
                VolverAlPueblo++;
                textoContador.text = VolverAlPueblo.ToString();
            }
        }
        if (VolverAlPueblo >= 7)
        {
            if (sonarVictoria == false)
            {
                StartCoroutine(GameManager.Instance.MusicaStopTimer(2.088f));
                GameManager.Instance.SonidoStop();
                GameManager.Instance.SonidoPlay(4);
                sonarVictoria = true;
            }
            canvasWinGame.SetActive(true);
            Continuar.gameObject.SetActive(true);
        }
    }


    private void NextQuestion()
    {
        if (VolverAlPueblo < 7)
        {
            quizUI.Construct(quizDB.GetRandom(), GiveAnswer);
        }
    }
    public void GiveAnswer(BotonOpcion optionbutton)
    {
        Comprobar(optionbutton);
    }


    void Comprobar(BotonOpcion optionbutton)
    {
        optionbutton.SetColor(optionbutton.Opciones.correcta ? colorcorrecto : colorincorrecto);

        if (optionbutton.Opciones.correcta)
        {
            Debug.Log("Acertaste " + optionbutton.name);
            GameManager.Instance.SonidoPlay(5);
            permitirTemp = true;
        }

        else
        {
            vidas -= 1;
            Debug.Log("Fallaste" + optionbutton.name);
            GameManager.Instance.SonidoPlay(6);
            if (vidas <= 0)
            {
                canvasGameOver.SetActive(true);
                Reiniciar.gameObject.SetActive(true);
            }
        }
    }
}
