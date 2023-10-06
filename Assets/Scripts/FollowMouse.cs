using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    // Variable para almacenar la distancia Z entre la c�mara y el objeto
    private float distanciaZ;

    // M�todo Start se llama una vez al inicio del juego
    void Start()
    {
        // Calcula la distancia Z entre la c�mara y el objeto
        distanciaZ = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);
    }

    // M�todo Update se llama una vez por fotograma
    void Update()
    {
        // Obt�n la posici�n del rat�n en el espacio del mundo
        Vector3 posicionRaton = Input.mousePosition;

        // Establece la distancia Z correcta para la posici�n del rat�n
        posicionRaton.z = distanciaZ;

        // Convierte la posici�n del rat�n de la pantalla a un punto en el espacio del mundo
        Vector3 posicionMundo = Camera.main.ScreenToWorldPoint(posicionRaton);

        // Establece la posici�n del GameObject para que siga al rat�n
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