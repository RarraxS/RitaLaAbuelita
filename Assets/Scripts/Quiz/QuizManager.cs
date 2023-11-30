using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(AudioSource))]
public class QuizManager : MonoBehaviour
{
    [SerializeField] private AudioClip sonidocorrecto = null;
    [SerializeField] private AudioClip sonidoincorrecto = null;
    [SerializeField] private Color colorcorrecto = Color.black;
    [SerializeField] private Color colorincorrecto = Color.black;
    [SerializeField] private float esperartiempo = 0.0f;
    [SerializeField] public int vidas = 1;
    [SerializeField] GameObject canvasGameOver;
    [SerializeField] GameObject Reiniciar;

    private Quiz quizDB = null;
    private QuizUI quizUI = null;
    private AudioSource quizAudioSource = null;

    private void Start()
    {
        quizDB = GameObject.FindObjectOfType<Quiz>();
        quizUI = GameObject.FindObjectOfType<QuizUI>();
        quizAudioSource = GetComponent<AudioSource>();
        canvasGameOver.SetActive(false);
        Reiniciar.gameObject.SetActive(false);
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
        if (quizAudioSource.isPlaying)
        {
            quizAudioSource.Stop();
        }
        quizAudioSource.clip = optionbutton.Opciones.correcta ? sonidocorrecto : sonidoincorrecto;
        optionbutton.SetColor(optionbutton.Opciones.correcta ? colorcorrecto : colorincorrecto);

        quizAudioSource.Play();

        yield return new WaitForSeconds(esperartiempo);
        NextQuestion();

        if (optionbutton.Opciones.correcta == true)
        {
            NextQuestion();
            Debug.Log("Acertaste");
        }

        if (optionbutton.Opciones.correcta == false)
        {
            vidas -= 1;
            Debug.Log("Fallaste");
            if (vidas == 0)
            {
                canvasGameOver.SetActive(true);
                Reiniciar.gameObject.SetActive(true);
            }
        }

    }
    public void CambiarEscena()
    {
        Debug.Log("Cambio de escena");
        SceneManager.LoadScene("Pueblo");
    }

}
