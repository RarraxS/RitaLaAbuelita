using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // Variable para almacenar la distancia Z entre la cámara y el objeto
    private float distanciaZ;

    // Método Start se llama una vez al inicio del juego
    void Start()
    {
        // Calcula la distancia Z entre la cámara y el objeto
        distanciaZ = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);
    }

    // Método Update se llama una vez por fotograma
    void Update()
    {
        // Obtén la posición del ratón en el espacio del mundo
        Vector3 posicionRaton = Input.mousePosition;

        // Establece la distancia Z correcta para la posición del ratón
        posicionRaton.z = distanciaZ;

        // Convierte la posición del ratón de la pantalla a un punto en el espacio del mundo
        Vector3 posicionMundo = Camera.main.ScreenToWorldPoint(posicionRaton);

        // Establece la posición del GameObject para que siga al ratón
        transform.position = posicionMundo;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Buscando" && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Dado");
            MinijuegoManager.Instance.timer += MinijuegoManager.Instance.tiempoGanadoPorAcertar;
            MinijuegoManager.Instance.DestructorNiveles();
        }

        if (collision.tag == "No buscando" && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Fallo");
            MinijuegoManager.Instance.timer -= MinijuegoManager.Instance.tiempoPerdidoPorFallar;
        }
    }
}