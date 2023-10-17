using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredienteBuscaObjetos : MonoBehaviour
{
    /*
    [SerializeField] int[] velocidadMaxima;
    [SerializeField] int[] velocidadMinima;

    int velocidadX, velocidadY;

    void Start()
    {
        velocidadX = Random.Range(velocidadMinima[MinijuegoManager.Instance.nivel], (velocidadMaxima[MinijuegoManager.Instance.nivel] + 1));
        velocidadY = Random.Range(velocidadMinima[MinijuegoManager.Instance.nivel], (velocidadMaxima[MinijuegoManager.Instance.nivel] + 1));
    }

    void Update()
    {
        transform.position += new Vector3(velocidadX, velocidadY, 0) * Time.deltaTime;
    }
    */

    void OnMouseDown()
    {
        if (tag == "Buscando" && MinijuegoManagerBuscaIngredientes.Instance.jugar == true)
        {
            MinijuegoManagerBuscaIngredientes.Instance.timer += MinijuegoManagerBuscaIngredientes.Instance.tiempoGanadoPorAcertar;
            MinijuegoManagerBuscaIngredientes.Instance.DestructorNiveles();
        }

        if (tag == "No buscando" && MinijuegoManagerBuscaIngredientes.Instance.jugar == true)
        {
            MinijuegoManagerBuscaIngredientes.Instance.timer -= MinijuegoManagerBuscaIngredientes.Instance.tiempoPerdidoPorFallar;
        }
    }
}