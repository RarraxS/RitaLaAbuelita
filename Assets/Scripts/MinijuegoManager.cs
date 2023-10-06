using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinijuegoManager : MonoBehaviour
{
    [SerializeField] public float timer;
    [SerializeField] public float tiempoPerdidoPorFallar;
    [SerializeField] public float tiempoGanadoPorAcertar;
    [SerializeField] GameObject[] prefabIngrediente;
    [SerializeField] int numeroDeNiveles;
    [SerializeField] int[] numeroDeObjetosPorNivel;
    [SerializeField] int NumeroTotalDeIngredientes;
    [SerializeField] float minimoValorEjeX;
    [SerializeField] float maximoValorEjeX;
    [SerializeField] float minimoValorEjeY;
    [SerializeField] float maximoValorEjeY;
    float valorEjeX, valorEjeY;

    int nivel = 0;

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
        NumeroTotalDeIngredientes = NumeroTotalDeIngredientes - 1;

        CreadorNiveles();
    }

    void Update()
    {
        timer = timer - Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.I))
        {
            DestructorNiveles();
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

        Debug.Log(nivel);

        CreadorNiveles();
    }
}