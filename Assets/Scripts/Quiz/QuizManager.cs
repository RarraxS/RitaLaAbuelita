using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(AudioSource))]
public class QuizManager : MonoBehaviour
{
    [SerializeField] private Color colorcorrecto = Color.black;
    [SerializeField] private Color colorincorrecto = Color.black;

    [SerializeField] private float esperartiempo = 0.0f;
    [SerializeField] public int vidas = 1;

    public bool preguntacorrecta = true;
    public bool preguntaincorrecta = false;

    [SerializeField] GameObject canvasGameOver;
    [SerializeField] GameObject Reiniciar;
    [SerializeField] GameObject canvasWinGame;
    [SerializeField] GameObject Continuar;

    public int VolverAlPueblo = 0;

   // [SerializeField] private List<Preguntas> preguntas = null;

    private Quiz quizDB = null;
    private QuizUI quizUI = null;

    private void Start()
    {
        quizDB = GameObject.FindObjectOfType<Quiz>();
        quizUI = GameObject.FindObjectOfType<QuizUI>();
        canvasGameOver.SetActive(false);
        Reiniciar.gameObject.SetActive(false);
        canvasWinGame.SetActive(false);
        Continuar.gameObject.SetActive(false);
        NextQuestion();
    }
    private void NextQuestion()
    {
        quizUI.Construct(quizDB.GetRandom(), GiveAnswer);
    }
    public void GiveAnswer(BotonOpcion optionbutton)
    {
        StartCoroutine(GiveAnswerRoutine(optionbutton));
    }
    private IEnumerator GiveAnswerRoutine(BotonOpcion optionbutton)
    {
        if (optionbutton.Opciones.correcta)
        {
            GameManager.Instance.SonidoPlay(15);
            Debug.Log("Acertaste " + optionbutton.name);
            NextQuestion();
            VolverAlPueblo++;
        }
        else
        {
            GameManager.Instance.SonidoPlay(16);
            vidas -= 1;
            Debug.Log("Fallaste" + optionbutton.name);
            if (vidas <= 0)
            {
                canvasGameOver.SetActive(true);
                Reiniciar.gameObject.SetActive(true);
            }

        }
        if (VolverAlPueblo >= 7) 
        {
            GameManager.Instance.SonidoStop();
            GameManager.Instance.SonidoPlay(13);
            canvasWinGame.SetActive(true);
            Continuar.gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(esperartiempo);
    }
}
