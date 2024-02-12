using UnityEngine;
using UnityEngine.SceneManagement;

public class CasaManager : MonoBehaviour
{
    [SerializeField] private GameObject cambioPueblo, cambioCocinar;

    private void Update()
    {
        CambioPueblo();
        CambioCocina();
    }

    private void CambioPueblo()
    {
        //Si se pulsa la tecla de interacción cuando se está frente a la alfombra de la casa de Rita
        //se va a la escena "Pueblo"
        if (Rita.Instance.collidedObject == cambioPueblo &&
            Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.escena = "Pueblo";
            GameManager.Instance.AmbienteStop();
            SceneManager.LoadScene("PantallaCarga");
        }
    }

    private void CambioCocina()
    {
        //Si se pulsa la tecla de interacción cuando se está frente a la encimera de la casa de Rita
        //se va a la escena "Cocinar"
        if (Rita.Instance.collidedObject == cambioCocinar && Input.GetKeyDown(KeyCode.Space) &&
            GameManager.Instance.quizCompletado == true && GameManager.Instance.buscaObjetosCompletado == true)
        {
            GameManager.Instance.posicionCasa = Rita.Instance.rita.transform.position;
            GameManager.Instance.escena = "Cocinar1";
            GameManager.Instance.AmbienteStop();
            SceneManager.LoadScene("PantallaCarga");
        }
    }
}
