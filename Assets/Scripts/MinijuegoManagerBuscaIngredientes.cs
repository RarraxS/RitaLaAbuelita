using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinijuegoManager : MonoBehaviour
{
    [SerializeField] public float timer;
    [SerializeField] public float tiempoPerdidoPorFallar;
    [SerializeField] public float tiempoGanadoPorAcertar;
    [SerializeField] GameObject[] prefabIngrediente;
    [SerializeField] GameObject canvasGameOver;
    [SerializeField] int numeroDeNiveles;
    [SerializeField] int[] numeroDeObjetosPorNivel;
    [SerializeField] int NumeroTotalDeIngredientes;
    [SerializeField] TMP_Text textNivel, textTiempo;
    [SerializeField] float minimoValorEjeX;
    [SerializeField] float maximoValorEjeX;
    [SerializeField] float minimoValorEjeY;
    [SerializeField] float maximoValorEjeY;
    float valorEjeX, valorEjeY;

    int nivel = 0;

    float timerInicio;

    int objeto;

    private static MinijuegoManager instance;
    public static MinijuegoManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);
    }

    void Start()
    {
        timerInicio = timer;

        NumeroTotalDeIngredientes = NumeroTotalDeIngredientes - 1;

        CreadorNiveles();

        canvasGameOver.SetActive(false);
    }

    void Update()
    {
        ActualizarHUD();
        if (timer > 0)
        {
            timer = timer - Time.deltaTime;
        }

        if (timer <= 0)
        {
            GamerOver();
        }
    }

    //Esta función es la encargada de crear niveles
    void CreadorNiveles()
    {
        objeto = 0;
        for (int i = numeroDeObjetosPorNivel[nivel]; i > 0; i--)
        {
            valorEjeX = Random.Range(minimoValorEjeX, (maximoValorEjeX + 0.1f));
            valorEjeY = Random.Range(minimoValorEjeY, (maximoValorEjeY + 0.1f));
            GameObject clon = Instantiate(prefabIngrediente[objeto]);
            clon.transform.position = new Vector3(valorEjeX, valorEjeY, 0);
            objeto = Random.Range(1, (NumeroTotalDeIngredientes + 1));
        }
    }

    // Esta función destruirá los objetos con los tags "Buscando" y "No buscando"
    public void DestructorNiveles()
    {
        GameObject[] objetosABuscar = GameObject.FindGameObjectsWithTag("Buscando");
        GameObject[] objetosNoBuscar = GameObject.FindGameObjectsWithTag("No buscando");

        foreach (GameObject objeto in objetosABuscar)
        {
            Destroy(objeto);
        }

        foreach (GameObject objeto in objetosNoBuscar)
        {
            Destroy(objeto);
        }


        nivel++;

        CreadorNiveles();
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
        canvasGameOver.SetActive(true);
    }

    public void Reintentar()
    {
        nivel = -1;

        DestructorNiveles();

        timer = timerInicio;

        canvasGameOver.SetActive(false);
    }
}