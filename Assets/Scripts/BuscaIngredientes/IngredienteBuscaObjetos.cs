using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredienteBuscaObjetos : MonoBehaviour
{
    
    [SerializeField] private int[] _velocidad;
    private Vector3 _direction;

    void Start()
    {
        Vector2 randomCircle = Random.insideUnitCircle;
        Vector3 randomPosition = new(randomCircle.x, randomCircle.y, 0);
        _direction = (randomPosition - transform.position).normalized;
    }

    void Update()
    {
        transform.Translate(Time.deltaTime * _velocidad[MinijuegoManagerBuscaIngredientes.Instance.Nivel] * _direction);
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
}
