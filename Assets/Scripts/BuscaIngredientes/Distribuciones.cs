using UnityEngine;

public class Distribuciones : MonoBehaviour
{
    [SerializeField] private ControladorSprites[] distribucion;
    [SerializeField] private int numeroObjeto;
    [SerializeField] private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Cambia el sprite del objeto por la distribuci�n que ha salido en el MinijuegoManager
        //y dentro de este por el n�mero de objeto que le corresponde a este objeto
        sr.sprite = distribucion[MinijuegoManagerBuscaIngredientes.Instance.distribucion].sprite[numeroObjeto];
    }
}
