using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using UnityEngine.Video;

public class Cuchillo : MonoBehaviour
{
    public CocinaManager managerCocina;
    string _zona;
    public int ganar = 0;
    private int num = 0;

    [SerializeField] GameObject canvasGameOver;
    [SerializeField] GameObject canvasWinGame;
    [SerializeField] GameObject Boton;

    [SerializeField] GameObject PatataCorte1izq;
    [SerializeField] GameObject PatataSinCorte;
    [SerializeField] GameObject PatataCorte1centroizq;
    [SerializeField] GameObject PatataCorte1centrodrcha;
    [SerializeField] GameObject PatataCorte1drcha;

    string uno = "Correcto1";
    string dos = "Correcto2";
    string tres = "Correcto3";
    string cuatro = "Correcto4";

    // Start is called before the first frame update
    void Start()
    {
        canvasGameOver.SetActive(false);
        canvasWinGame.SetActive(false);
        Boton.gameObject.SetActive(true);
        PatataSinCorte.gameObject.SetActive(true);
        PatataCorte1izq.SetActive(false);
        PatataCorte1centroizq.SetActive(false);
        PatataCorte1centrodrcha.SetActive(false);
        PatataCorte1drcha.SetActive(false);

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
        if(_zona != string.Empty)
        {
            ganar++;
            if (ganar == 1)
            {
                if (_zona == uno)
                {
                    PatataSinCorte.gameObject.SetActive(false);
                    PatataCorte1izq.SetActive(true);
                    num = 1;
                }
                if (_zona == dos)
                {
                    PatataSinCorte.gameObject.SetActive(false);
                    PatataCorte1centroizq.SetActive(true);
                    num = 2;
                }
                if (_zona == tres)
                {
                    PatataSinCorte.gameObject.SetActive(false);
                    PatataCorte1centrodrcha.SetActive(true);
                    num = 3;
                }
                if (_zona == cuatro)
                {
                    PatataSinCorte.gameObject.SetActive(false);
                    PatataCorte1drcha.SetActive(true);
                    num = 4;
                }
            }
            //if (ganar == 2)
            //{
            //    if (_zona == uno) //Corte num 1
            //    {
            //        if(num == 2) 
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 12;
            //        }
            //        if(num == 3)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 13;
            //        }
            //        if (num == 4)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 14;
            //        }
            //    }
            //    if (_zona == dos) //Corte num 2
            //    {
            //        if (num == 1)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 21;
            //        }
            //        if (num == 3)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 23;
            //        }
            //        if (num == 4)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 24;
            //        }
            //    }
            //    if (_zona == tres) //Corte num 3
            //    {
            //        if (num == 1)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 31;
            //        }
            //        if (num == 2)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 32;
            //        }
            //        if (num == 4)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 34;
            //        }
            //    }
            //    if (_zona == cuatro) //Corte num 4
            //    {
            //        if (num == 1)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 41;
            //        }
            //        if (num == 2)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 42;
            //        }
            //        if (num == 3)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 43;
            //        }
            //    }
            //}
            //if (ganar == 3)
            //{
            //    if (_zona == uno) //Corte num 1 y 2
            //    {
            //        if(num == 2) 
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 12;
            //        }
            //        if(num == 3)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 13;
            //        }
            //        if (num == 4)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 14;
            //        }
            //    }
            //    if (_zona == dos) //Corte num 2
            //    {
            //        if (num == 1)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 21;
            //        }
            //        if (num == 3)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 23;
            //        }
            //        if (num == 4)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 24;
            //        }
            //    }
            //    if (_zona == tres) //Corte num 3
            //    {
            //        if (num == 1)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 31;
            //        }
            //        if (num == 2)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 32;
            //        }
            //        if (num == 4)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 34;
            //        }
            //    }
            //    if (_zona == cuatro) //Corte num 4
            //    {
            //        if (num == 1)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 41;
            //        }
            //        if (num == 2)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 42;
            //        }
            //        if (num == 3)
            //        {
            //            PatataSinCorte.gameObject.SetActive(false);
            //            PatataCorte1izq.SetActive(true);
            //            num = 43;
            //        }
            //    }
            //}

            Destroy(GameObject.FindGameObjectWithTag(_zona));
            _zona = string.Empty;
            Debug.Log("Acertaste");
            if(ganar >= 4)
            {
                Ganaste();
            }
        }
        else
        {
            managerCocina.vidas--;
            Debug.Log("Fallaste");
            if (managerCocina.vidas <= 0 )
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
        if (ganar >= 4)
        {
            canvasWinGame.SetActive(true);
            Boton.gameObject.SetActive(false);
        }
    }
}

