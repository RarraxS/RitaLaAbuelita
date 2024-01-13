using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PuebloManager : MonoBehaviour
{
    public GameObject collidedObject, cambioBuscaObjetos, cambioQuiz;

    private static PuebloManager instance;
    public static PuebloManager Instance
    {
        get { return instance; }
    }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        GameManager.Instance.AmbientePlay(4);
    }

    void Update()
    {
        CambioBuscaObjetos();
        CambioQuiz();
    }

    void CambioBuscaObjetos()
    {
        if (PuebloManager.Instance.collidedObject == PuebloManager.Instance.cambioBuscaObjetos && Input.GetKey(KeyCode.Space))
        {
            GameManager.Instance.position = Rita.Instance.rita.transform.position;
            GameManager.Instance.escena = "PulsarIngredientes";
            GameManager.Instance.AmbienteStop();
            SceneManager.LoadScene("PantallaCarga");
        }
    }

    void CambioQuiz()
    {
        if (PuebloManager.Instance.collidedObject == PuebloManager.Instance.cambioQuiz && 
            ((Input.GetKeyDown(KeyCode.U) && GameManager.Instance.controles == "zurdo") ||
            (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.controles == "diestro")))
        {
            GameManager.Instance.position = Rita.Instance.rita.transform.position;
            GameManager.Instance.escena = "Quiz";
            GameManager.Instance.AmbienteStop();
            SceneManager.LoadScene("PantallaCarga");
        }
    }
}