using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionesRita : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.layer == 6)
        {
            // Accede al GameObject con el que ha colisionado
            Rita.Instance.collidedObject = collision.gameObject;
        }
    }
}
