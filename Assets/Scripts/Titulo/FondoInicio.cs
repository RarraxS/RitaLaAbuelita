using UnityEngine;
using UnityEngine.SceneManagement;

public class FondoInicio : MonoBehaviour
{
    //Tenemos un timer y una variable bool que indica si está activado o no
    private float timer = 1.75f;
    public bool timerActivado = false;

    public Animator animator;

    private static FondoInicio instance;
    public static FondoInicio Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Como lo que acemos es agrandar la pantalla mediante una animación, hay que cambiar
        //de escena antes de que vuelva a la posición inicial y se reproduzca otra vez la animación
        //por eso tenemos un timer, el cual comienza a contar cuando la animación de la pantalla
        //y cuando a este llega a 0 cambia a la siguiente escena
        if (timerActivado == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            SceneManager.LoadScene("PantallaCarga");
            GameManager.Instance.escena = "CasaRita";
        }
    }
}
