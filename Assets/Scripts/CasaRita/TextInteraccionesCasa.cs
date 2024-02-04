using UnityEngine;

public class TextInteraccionesCasa : MonoBehaviour
{
    [SerializeField] private Transform targetObject;  // Referencia al GameObject que seguir� el objeto de texto.
    [SerializeField] private RectTransform textTransform;
    [SerializeField] private Vector3 VerticalOffset;

    void Update()
    {
        if (targetObject != null)
        {
            // Calcula la posici�n a la que el texto debe seguir al objeto.
            Vector3 targetPosition = Camera.main.WorldToScreenPoint(targetObject.position);

            // Asigna la nueva posici�n al objeto de texto.
            textTransform.position = targetPosition + VerticalOffset;
        }
    }
}

