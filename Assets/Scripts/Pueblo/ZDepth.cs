using UnityEngine;

public class ZDepth : MonoBehaviour
{
    void Start()
    {
        //Hace que el iniciar el pueblo todo se ponga a la profundidad que le toca
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.y);
        transform.position = newPosition;
    }
}
