using UnityEngine;
using System;
using System.Drawing;

public class TextInteraccionesCasa : MonoBehaviour
{
    public Transform targetObject;  // Referencia al GameObject que seguirá el objeto de texto.
    public Transform textTransform;
    private Vector3 distancia = new Vector3(525, 300, 0);
    private int velocidad = 2;
    public Vector3 VerticalOffset;

    void Update()
    {
        if (targetObject != null)
        {
            // Calcula la posición a la que el texto debe seguir al objeto.
            Vector3 targetPosition = Camera.main.WorldToScreenPoint(targetObject.position);

            // Asigna la nueva posición al objeto de texto.
            textTransform.position = targetPosition + VerticalOffset;
        }
    }
}

