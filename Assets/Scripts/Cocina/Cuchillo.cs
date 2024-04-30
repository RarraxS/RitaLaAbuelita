using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class Cuchillo : MonoBehaviour
{
    public CocinaManager managerCocina;
    string _zona;
    public int ganar = 0;
    private int num = 0;

    float secondsCounter = 0;
    float secondsToCount = 3;

    [SerializeField] GameObject canvasGameOver;
    [SerializeField] GameObject canvasWinGame;
    [SerializeField] GameObject Boton;


    [SerializeField] GameObject PatataSinCorte;

    //Ganar=1
    [SerializeField] GameObject PatataCorte1;
    [SerializeField] GameObject PatataCorte2;
    [SerializeField] GameObject PatataCorte3;
    [SerializeField] GameObject PatataCorte4;

    //Ganar=2
    [SerializeField] GameObject PatataCorte12;
    [SerializeField] GameObject PatataCorte13;
    [SerializeField] GameObject PatataCorte14;
    [SerializeField] GameObject PatataCorte23;
    [SerializeField] GameObject PatataCorte24;
    [SerializeField] GameObject PatataCorte34;

    //Ganar=3
    [SerializeField] GameObject PatataCorte123;
    [SerializeField] GameObject PatataCorte124;
    [SerializeField] GameObject PatataCorte234;
    [SerializeField] GameObject PatataCorte134;

    //Ganar=4
    [SerializeField] GameObject PatataConCortes;

    string uno = "Correcto1";
    string dos = "Correcto2";
    string tres = "Correcto3";
    string cuatro = "Correcto4";

    [SerializeField] public TMP_Text textoContador;

    // Start is called before the first frame update
    void Start()
    {
        canvasGameOver.SetActive(false);
        canvasWinGame.SetActive(false);
        Boton.gameObject.SetActive(true);

        PatataSinCorte.gameObject.SetActive(true);

        PatataCorte1.SetActive(false);
        PatataCorte2.SetActive(false);
        PatataCorte3.SetActive(false);
        PatataCorte4.SetActive(false);

        PatataCorte12.SetActive(false);
        PatataCorte13.SetActive(false);
        PatataCorte14.SetActive(false);
        PatataCorte23.SetActive(false);
        PatataCorte24.SetActive(false);
        PatataCorte34.SetActive(false);

        PatataCorte123.SetActive(false);
        PatataCorte124.SetActive(false);
        PatataCorte234.SetActive(false);
        PatataCorte134.SetActive(false);

        PatataConCortes.SetActive(false);

        textoContador.text = managerCocina.vidas.ToString();
        _zona = string.Empty;
    }
    void Update()
    {
        textoContador.text = managerCocina.vidas.ToString();
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
        if (_zona != string.Empty)
        {
            ganar++;

            if (ganar == 1)
            {
                if (_zona == uno)
                {
                    PatataSinCorte.gameObject.SetActive(false);
                    PatataCorte1.SetActive(true);
                    num = 1;
                }
                if (_zona == dos)
                {
                    PatataSinCorte.gameObject.SetActive(false);
                    PatataCorte2.SetActive(true);
                    num = 2;
                }
                if (_zona == tres)
                {
                    PatataSinCorte.gameObject.SetActive(false);
                    PatataCorte3.SetActive(true);
                    num = 3;
                }
                if (_zona == cuatro)
                {
                    PatataSinCorte.gameObject.SetActive(false);
                    PatataCorte4.SetActive(true);
                    num = 4;
                }
            }

            if (ganar == 2)
            {
                if (_zona == uno) //Corte num 1
                {
                    if (num == 2)
                    {
                        PatataCorte2.gameObject.SetActive(false);
                        PatataCorte12.SetActive(true);
                        num = 12;
                    }
                    if (num == 3)
                    {
                        PatataCorte3.gameObject.SetActive(false);
                        PatataCorte13.SetActive(true);
                        num = 13;
                    }
                    if (num == 4)
                    {
                        PatataCorte4.gameObject.SetActive(false);
                        PatataCorte14.SetActive(true);
                        num = 14;
                    }
                }
                if (_zona == dos) //Corte num 2
                {
                    if (num == 1)
                    {
                        PatataCorte1.gameObject.SetActive(false);
                        PatataCorte12.SetActive(true);
                        num = 12;
                    }
                    if (num == 3)
                    {
                        PatataCorte3.gameObject.SetActive(false);
                        PatataCorte23.SetActive(true);
                        num = 23;
                    }
                    if (num == 4)
                    {
                        PatataCorte4.gameObject.SetActive(false);
                        PatataCorte24.SetActive(true);
                        num = 24;
                    }
                }
                if (_zona == tres) //Corte num 3
                {
                    if (num == 1)
                    {
                        PatataCorte1.gameObject.SetActive(false);
                        PatataCorte13.SetActive(true);
                        num = 13;
                    }
                    if (num == 2)
                    {
                        PatataCorte2.gameObject.SetActive(false);
                        PatataCorte23.SetActive(true);
                        num = 23;
                    }
                    if (num == 4)
                    {
                        PatataCorte4.gameObject.SetActive(false);
                        PatataCorte34.SetActive(true);
                        num = 34;
                    }
                }
                if (_zona == cuatro) //Corte num 4
                {
                    if (num == 1)
                    {
                        PatataCorte1.gameObject.SetActive(false);
                        PatataCorte14.SetActive(true);
                        num = 14;
                    }
                    if (num == 2)
                    {
                        PatataCorte2.gameObject.SetActive(false);
                        PatataCorte24.SetActive(true);
                        num = 24;
                    }
                    if (num == 3)
                    {
                        PatataCorte3.gameObject.SetActive(false);
                        PatataCorte34.SetActive(true);
                        num = 34;
                    }
                }
            }

            if (ganar == 3)
            {
                if (_zona == uno) //Corte num 1
                {
                    if (num == 23)
                    {
                        PatataCorte23.gameObject.SetActive(false);
                        PatataCorte123.SetActive(true);
                    }
                    if (num == 24)
                    {
                        PatataCorte24.gameObject.SetActive(false);
                        PatataCorte124.SetActive(true);
                    }
                    if (num == 34)
                    {
                        PatataCorte34.gameObject.SetActive(false);
                        PatataCorte134.SetActive(true);
                    }
                }
                if (_zona == dos) //Corte num 2
                {
                    if (num == 13)
                    {
                        PatataCorte13.gameObject.SetActive(false);
                        PatataCorte123.SetActive(true);
                    }
                    if (num == 14)
                    {
                        PatataCorte14.gameObject.SetActive(false);
                        PatataCorte124.SetActive(true);
                    }
                    if (num == 34)
                    {
                        PatataCorte34.gameObject.SetActive(false);
                        PatataCorte234.SetActive(true);
                    }
                }
                if (_zona == tres) //Corte num 3
                {
                    if (num == 12)
                    {
                        PatataCorte12.gameObject.SetActive(false);
                        PatataCorte123.SetActive(true);
                    }
                    if (num == 14)
                    {
                        PatataCorte14.gameObject.SetActive(false);
                        PatataCorte134.SetActive(true);
                    }
                    if (num == 24)
                    {
                        PatataCorte24.gameObject.SetActive(false);
                        PatataCorte234.SetActive(true);
                    }
                }
                if (_zona == cuatro) //Corte num 4
                {
                    if (num == 12)
                    {
                        PatataCorte12.gameObject.SetActive(false);
                        PatataCorte124.SetActive(true);
                    }
                    if (num == 13)
                    {
                        PatataCorte13.gameObject.SetActive(false);
                        PatataCorte134.SetActive(true);
                    }
                    if (num == 23)
                    {
                        PatataCorte23.gameObject.SetActive(false);
                        PatataCorte234.SetActive(true);
                    }
                }
            }

            if (ganar >= 4)
            {
                PatataCorte123.SetActive(false);
                PatataCorte134.SetActive(false);
                PatataCorte234.SetActive(false);
                PatataConCortes.SetActive(true);
                Destroy(GameObject.FindGameObjectWithTag(_zona));
                _zona = string.Empty;
                Debug.Log("Acertaste");
                Ganaste();
            }

            Destroy(GameObject.FindGameObjectWithTag(_zona));
            _zona = string.Empty;
            Debug.Log("Acertaste");
        }
        else
        {
            managerCocina.vidas--;
            textoContador.text = managerCocina.vidas.ToString();
            Debug.Log("Fallaste");
            if (managerCocina.vidas <= 0)
            {
                Morir();
            }
        }
    }
    public void Morir()
    {
        if (managerCocina.vidas <= 0)
        {
            canvasGameOver.SetActive(true);
            Boton.gameObject.SetActive(false);
        }
    }
    public void Ganaste()
    {
        secondsCounter += Time.deltaTime;
        if (secondsCounter >= secondsToCount)
        {
            secondsCounter = 0;
        }
        if (ganar >= 4)
        {
            canvasWinGame.SetActive(true);
            Boton.gameObject.SetActive(false);

            //Los sonidos de victoria
            StartCoroutine(GameManager.Instance.MusicaStopTimer(2.088f));
            GameManager.Instance.SonidoStop();
            GameManager.Instance.SonidoPlay(13);
        }
    }
}

