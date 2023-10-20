using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredienteBuscaObjetos : MonoBehaviour
{
    
    [SerializeField] private int[] _velocidad;
    private Vector3 _direction;
    Vector2 randomCircle = Random.insideUnitCircle;

    void Start()
    {
        Vector3 randomPosition = new(randomCircle.x, randomCircle.y, 0);
        _direction = (randomPosition - transform.position).normalized;
    }

    void Update()
    {
        transform.Translate(Time.deltaTime * _velocidad[MinijuegoManagerBuscaIngredientes.Instance.Nivel] * _direction);

        CorregirPosicion();
    }
    

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

    void CorregirPosicion()
    {
        if (randomCircle.x <= MinijuegoManagerBuscaIngredientes.Instance.minimoValorEjeX)
        {
            randomCircle.x = MinijuegoManagerBuscaIngredientes.Instance.maximoValorEjeX;
            Debug.Log("Derecha");
        }

        if (randomCircle.x >= MinijuegoManagerBuscaIngredientes.Instance.maximoValorEjeX)
        {
            randomCircle.x = MinijuegoManagerBuscaIngredientes.Instance.minimoValorEjeX;
            Debug.Log("Izquierda");
        }

        if (randomCircle.y <= MinijuegoManagerBuscaIngredientes.Instance.minimoValorEjeY)
        {
            randomCircle.y = MinijuegoManagerBuscaIngredientes.Instance.maximoValorEjeY;
            Debug.Log("Abajo");
        }

        if (randomCircle.y >= MinijuegoManagerBuscaIngredientes.Instance.maximoValorEjeY)
        {
            randomCircle.y = MinijuegoManagerBuscaIngredientes.Instance.minimoValorEjeY;
            Debug.Log("Arriba");
        }
    }
}
