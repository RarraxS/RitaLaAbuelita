using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Cuchillo_2 : MonoBehaviour
{
    public CocinaManager managerCocina;
    string _zona;
    public int ganar = 0;

    [SerializeField] GameObject canvasGameOver;
    [SerializeField] GameObject canvasWinGame;
    [SerializeField] GameObject Boton;


    // Start is called before the first frame update
    void Start()
    {
        canvasGameOver.SetActive(false);
        canvasWinGame.SetActive(false);
        Boton.gameObject.SetActive(true);
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
        if (_zona != string.Empty)
        {
            Destroy(GameObject.FindGameObjectWithTag(_zona));
            _zona = string.Empty;
            ganar++;
            Debug.Log("Acertaste");
            if (ganar >= 6)
            {
                Ganaste();
            }
        }
        else
        {
            managerCocina.vidas--;
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
        if (ganar >= 6)
        {
            canvasWinGame.SetActive(true);
            Boton.gameObject.SetActive(false);
        }
    }
}
