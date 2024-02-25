using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

[RequireComponent(typeof(AudioSource))]
public class QuizManager : MonoBehaviour
{
    [SerializeField] private Color colorcorrecto = Color.black;
    [SerializeField] private Color colorincorrecto = Color.black;

    //[SerializeField] private float esperartiempo = 0.0f;
    [SerializeField] public int vidas = 1;

    public bool preguntacorrecta = true;
    public bool preguntaincorrecta = false;

    [SerializeField] GameObject canvasGameOver;
    [SerializeField] GameObject Reiniciar;
    [SerializeField] GameObject canvasWinGame;
    [SerializeField] GameObject Continuar;

    //[SerializeField] private AudioClip sonidocorrecto = null;
    //[SerializeField] private AudioClip sonidoincorrecto = null;

    public int VolverAlPueblo = 0;
    public TMP_Text textoContador;
    //[SerializeField] private List<Preguntas> preguntas = null;

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
                GameManager.Instance.SonidoPlay(13);
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
        //StartCoroutine(GiveAnswerRoutine(optionbutton));

        Comprobar(optionbutton);
    }


    void Comprobar(BotonOpcion optionbutton)
    {
        optionbutton.SetColor(optionbutton.Opciones.correcta ? colorcorrecto : colorincorrecto);

        if (optionbutton.Opciones.correcta)
        {
            Debug.Log("Acertaste " + optionbutton.name);
            GameManager.Instance.SonidoPlay(15);
            permitirTemp = true;
        }

        else
        {
            vidas -= 1;
            Debug.Log("Fallaste" + optionbutton.name);
            GameManager.Instance.SonidoPlay(16);
            if (vidas <= 0)
            {
                canvasGameOver.SetActive(true);
                Reiniciar.gameObject.SetActive(true);
            }
        }
    }





    //private IEnumerator GiveAnswerRoutine(BotonOpcion optionbutton)
    //{
    //    if (quizAudioSource.isPlaying)
    //    {
    //        quizAudioSource.Stop();
    //    }

    //    quizAudioSource.clip = optionbutton.Opciones.correcta ? sonidocorrecto : sonidoincorrecto;

    //    optionbutton.SetColor(optionbutton.Opciones.correcta ? colorcorrecto : colorincorrecto);

    //    yield return new WaitForSeconds(esperartiempo);
    //    //NextQuestion();

    //    if (optionbutton.Opciones.correcta)
    //    {
    //        Debug.Log("Acertaste " + optionbutton.name);
    //        NextQuestion();
    //        //GameManager.Instance.SonidoPlay(15);
    //        VolverAlPueblo++;
    //    }
    //    else
    //    {
    //        vidas -= 1;
    //        Debug.Log("Fallaste" + optionbutton.name);
    //        //GameManager.Instance.SonidoPlay(16);
    //        if (vidas <= 0)
    //        {
    //            canvasGameOver.SetActive(true);
    //            Reiniciar.gameObject.SetActive(true);
    //        }

    //    }
    //    if (VolverAlPueblo == 7) 
    //    {
    //        canvasWinGame.SetActive(true);
    //        Continuar.gameObject.SetActive(true);
    //        //GameManager.Instance.SonidoStop();
    //        //GameManager.Instance.SonidoPlay(13);
    //    }

    //    //public void CambiarEscena()
    //    //{
    //    //    Debug.Log("Cambio de escena");
    //    //    SceneManager.LoadScene("Pueblo");
    //    //}

    //}
}
