using UnityEngine;
using UnityEngine.UI;

public class DistribucionIndicador : MonoBehaviour
{
    [SerializeField] private ControladorSprites[] distribucion;
    [SerializeField] private int numeroObjeto;
    [SerializeField] private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        //Cambia el sprite del marcador de objetos por el de la distribución que ha salido en el
        //MinijuegoManager y dentro de este por el número de objeto que le corresponde a este objeto
        image.sprite = distribucion[MinijuegoManagerBuscaIngredientes.Instance.distribucion].sprite[numeroObjeto];
    }
}
