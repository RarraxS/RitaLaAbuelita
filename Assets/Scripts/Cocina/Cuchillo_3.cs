using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class Cuchillo_3 : MonoBehaviour
{
    public CocinaManager managerCocina;
    string _zona;
    public int ganar;
    private int vidas = 2;

    [SerializeField] GameObject canvasGameOver;
    [SerializeField] GameObject canvasWinGame;
    [SerializeField] GameObject Boton;

    [SerializeField] GameObject HornoFrio;
    [SerializeField] GameObject HornoTemplado;
    [SerializeField] GameObject HornoCaliente;

    string uno = "Correcto1";
    string dos = "Correcto2";

    [SerializeField] public TMP_Text textoContador;

    // Start is called before the first frame update
    void Start()
    {
        canvasGameOver.SetActive(false);
        canvasWinGame.SetActive(false);
        Boton.gameObject.SetActive(true);

        HornoFrio.gameObject.SetActive(true);

        HornoTemplado.SetActive(false);
        HornoCaliente.SetActive(false);

        ganar = 0;

        textoContador.text = vidas.ToString();

        _zona = string.Empty;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _zona = collision.tag;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _zona = string.Empty;
    }

    public void Corte()
    {
        //Sonidos -------------------------------------------------------------

        GameManager.Instance.SonidoStop();
        GameManager.Instance.SonidoPlay(7);

        //---------------------------------------------------------------------


        if (_zona != string.Empty)
        {
            ganar++;

            if(ganar==1)
            {
                HornoFrio.gameObject.SetActive(false);
                HornoTemplado.SetActive(true);
            }
            if (ganar==2)
            {
                HornoTemplado.SetActive(false);
                HornoCaliente.SetActive(true);
                //Destroy(GameObject.FindGameObjectWithTag(_zona));
                //_zona = string.Empty;
                //Debug.Log("Acertaste");
                //Ganaste();
            }

            Destroy(GameObject.FindGameObjectWithTag(_zona));
            _zona = string.Empty;
            Debug.Log("Acertaste");

            if (ganar == 2)
            {
                Ganaste();
            }
        }
        else
        {
            vidas--;
            textoContador.text = vidas.ToString();
            Debug.Log("Fallaste");
            if (vidas <= 0)
            {
                Morir();
            }
        }
    }
    public void Morir()
    {
        if (vidas <= 0)
        {
            //Sonidos --------------------------------------------------

            GameManager.Instance.SonidoStop();
            GameManager.Instance.SonidoPlay(6);

            //----------------------------------------------------------

            canvasGameOver.SetActive(true);
            Boton.gameObject.SetActive(false);
        }
    }
    public void Ganaste()
    {
        canvasWinGame.SetActive(true);
        Boton.gameObject.SetActive(false);
        //Los sonidos de victoria
        StartCoroutine(GameManager.Instance.MusicaStopTimer(2.088f));
        GameManager.Instance.SonidoStop();
        GameManager.Instance.SonidoPlay(5);
    }
}
