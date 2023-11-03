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
        if (transform.position.x <= MinijuegoManagerBuscaIngredientes.Instance.minimoValorEjeX)
        {
            transform.position = new Vector3(MinijuegoManagerBuscaIngredientes.Instance.maximoValorEjeX, transform.position.y, transform.position.z);
            Debug.Log("Izquierda");
        }

        if (transform.position.x >= MinijuegoManagerBuscaIngredientes.Instance.maximoValorEjeX)
        {
            transform.position = new Vector3(MinijuegoManagerBuscaIngredientes.Instance.minimoValorEjeX, transform.position.y, transform.position.z);
            //Debug.Log("Derecha");
        }

        if (transform.position.y <= MinijuegoManagerBuscaIngredientes.Instance.minimoValorEjeY)
        {
            transform.position = new Vector3(transform.position.x, MinijuegoManagerBuscaIngredientes.Instance.maximoValorEjeY, transform.position.z);
            //Debug.Log("Abajo");
        }

        if (transform.position.y >= MinijuegoManagerBuscaIngredientes.Instance.maximoValorEjeY)
        {
            transform.position = new Vector3(transform.position.x, MinijuegoManagerBuscaIngredientes.Instance.minimoValorEjeY, transform.position.z);
            //Debug.Log("Arriba");
        }
    }
}
