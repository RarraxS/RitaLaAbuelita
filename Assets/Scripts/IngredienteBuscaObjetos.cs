using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredienteBuscaObjetos : MonoBehaviour
{
    void OnMouseDown()
    {
        if (tag == "Buscando" )
        {
            Debug.Log("Dado");
            MinijuegoManager.Instance.timer += MinijuegoManager.Instance.tiempoGanadoPorAcertar;
            MinijuegoManager.Instance.DestructorNiveles();
        }

        if (tag == "No buscando")
        {
            Debug.Log("Fallo");
            MinijuegoManager.Instance.timer -= MinijuegoManager.Instance.tiempoPerdidoPorFallar;
        }
    }
}
