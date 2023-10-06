using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredienteBuscaCaras : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
