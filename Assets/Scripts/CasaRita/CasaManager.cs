using UnityEngine;
using UnityEngine.SceneManagement;

public class CasaManager : MonoBehaviour
{
    [SerializeField] private GameObject cambioPueblo;

    private void Update()
    {
        CambioPueblo();
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
}
