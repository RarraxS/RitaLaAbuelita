using UnityEngine;

public class TextInteraccionesCasa : MonoBehaviour
{
    public Transform targetObject;  // Referencia al GameObject que seguirá el objeto de texto.
    private Vector3 distancia = new Vector3(525, 300, 0);
    private int velocidad = 2;

    void Update()
    {
        if (targetObject != null)
        {
            // Calcula la posición a la que el texto debe seguir al objeto.
            Vector3 targetPosition = targetObject.position + distancia;

            // Asigna la nueva posición al objeto de texto.
            transform.position = targetPosition;
        }
    }
}

