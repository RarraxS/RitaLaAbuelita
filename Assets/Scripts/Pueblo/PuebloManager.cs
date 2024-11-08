using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        GameManager.Instance.AmbientePlay(3);
    }

    private void Update()
    {
        CambioCasaRita();
        CambioBuscaObjetos();
        //CambioQuiz();
    }


    private void CambioCasaRita()
    {
        //Si se pulsa la tecla de interacci�n cuando se est� frente a la casa de Rita,
        //se guarda la posici�n de Rita para cuando se vuelva a la escena y se le dice
        //a que escena debe ir tras acabar la pantalla de carga
        if (Rita.Instance.collidedObject == cambioCasaRita &&
            Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.posicionPueblo = Rita.Instance.rita.transform.position;
            GameManager.Instance.escena = "CasaRita";
            GameManager.Instance.AmbienteStop();
            SceneManager.LoadScene("PantallaCarga");
        }
    }

    private void CambioQuiz()
    {
        //Esta funci�n ha sido reemplazada por otra iguak en el script de la UI de di�logo
        //para que te lleve al minijuego al finalizar el primer di�logo con Concha

        //Si se pulsa la tecla de interacci�n cuando se est� frente al NPC, se guarda la 
        //posici�n de Rita para cuando se vuelva a la escena y se le dice a que escena
        //debe ir tras acabar la pantalla de carga
        if (Rita.Instance.collidedObject == cambioQuiz &&
            Input.GetKeyDown(KeyCode.Space) && GameManager.Instance.quizCompletado == false)
        {
            GameManager.Instance.posicionPueblo = Rita.Instance.rita.transform.position;
            GameManager.Instance.escena = "Quiz";
            GameManager.Instance.AmbienteStop();
            SceneManager.LoadScene("PantallaCarga");
        }
    }

    private void CambioBuscaObjetos()
    {
        //Si se pulsa la tecla espacio cuando se est� frente a la tienda, se guarda la 
        //posici�n de Rita para cuando se vuelva a la escena y se le dice a que escena
        //debe ir tras acabar la pantalla de carga
        if (Rita.Instance.collidedObject == cambioBuscaObjetos &&
            Input.GetKey(KeyCode.Space) && GameManager.Instance.quizCompletado == true && 
            GameManager.Instance.buscaObjetosCompletado == false)
        {
            GameManager.Instance.posicionPueblo = Rita.Instance.rita.transform.position;
            GameManager.Instance.escena = "PulsarIngredientes";
            GameManager.Instance.AmbienteStop();
            SceneManager.LoadScene("PantallaCarga");
        }
    }
}