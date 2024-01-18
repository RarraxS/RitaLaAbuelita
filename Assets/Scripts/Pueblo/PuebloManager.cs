using UnityEngine;
using UnityEngine.SceneManagement;

public class PuebloManager : MonoBehaviour
{
    public GameObject cambioBuscaObjetos, cambioQuiz, cambioCasaRita;

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
        //Al iniciarse la escena empiezan a sonar los sonidos de ambiente del pueblo
        GameManager.Instance.AmbientePlay(4);
    }

    private void Update()
    {
        CambioCasaRita();
        CambioBuscaObjetos();
        CambioQuiz();
    }


    private void CambioCasaRita()
    {
        //Si se pulsa la tecla de interacción cuando se está frente a la casa de Rita,
        //se guarda la posición de Rita para cuando se vuelva a la escena y se le dice
        //a que escena debe ir tras acabar la pantalla de carga
        if (Rita.Instance.collidedObject == PuebloManager.Instance.cambioCasaRita &&
            Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.position = Rita.Instance.rita.transform.position;
            GameManager.Instance.escena = "CasaRita";
            GameManager.Instance.AmbienteStop();
            SceneManager.LoadScene("PantallaCarga");
        }
    }

    private void CambioBuscaObjetos()
    {
        //Si se pulsa la tecla espacio cuando se está frente a la tienda, se guarda la 
        //posición de Rita para cuando se vuelva a la escena y se le dice a que escena
        //debe ir tras acabar la pantalla de carga
        if (Rita.Instance.collidedObject == PuebloManager.Instance.cambioBuscaObjetos && Input.GetKey(KeyCode.Space))
        {
            GameManager.Instance.position = Rita.Instance.rita.transform.position;
            GameManager.Instance.escena = "PulsarIngredientes";
            GameManager.Instance.AmbienteStop();
            SceneManager.LoadScene("PantallaCarga");
        }
    }

    void CambioQuiz()
    {
        //Si se pulsa la tecla de interacción cuando se está frente al NPC, se guarda la 
        //posición de Rita para cuando se vuelva a la escena y se le dice a que escena
        //debe ir tras acabar la pantalla de carga
        if (Rita.Instance.collidedObject == PuebloManager.Instance.cambioQuiz && 
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