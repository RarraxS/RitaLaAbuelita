using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private float timer = 0.55f;
    public bool salida = false;
    private bool entrado = false;

    private static MenuPausa instance;
    public static MenuPausa Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (GameManager.Instance.canvasPausa.activeSelf && animator.GetInteger("menuPausa") == 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                animator.SetInteger("menuPausa", 1);
                timer = 0.55f;
            }
        }

        if (GameManager.Instance.canvasPausa.activeSelf && salida == true)
        {
            if (entrado == false)
            {
                animator.SetInteger("menuPausa", 2);
                entrado = true;
            }

            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = 0.55f;
                GameManager.Instance.canvasPausa.SetActive(false);
                entrado = false;

                GameManager.Instance.canvasControles.SetActive(true);

                if (GameManager.Instance.escena == "Pueblo")
                {
                    Rita.Instance.permitirMovimiento = true;
                }

                if (GameManager.Instance.escena == "PulsarIngredientes")
                {
                    MinijuegoManagerBuscaIngredientes.Instance.jugar = true;
                }

                if (GameManager.Instance.escena == "Quiz")
                {
                    GameManager.Instance.canvasQuiz.SetActive(true);
                }
            }
        }
    }

    public void Reanudar()
    {
        salida = true;
    }

    public void Reiniciar()
    {
        GameManager.Instance.canvasPausa.SetActive(false);
        GameManager.Instance.buscaObjetosCompletado = false;
        GameManager.Instance.quizCompletado = false;
        GameManager.Instance.audioSourceMusica.volume = 0.5f;
        GameManager.Instance.audioSourceSonidos.volume = 0.5f;
        GameManager.Instance.audioSourceAmbienteSonidos.volume = 0.5f;

        GameManager.Instance.escena = "Titulo";
        SceneManager.LoadScene("PantallaCarga");
    }

    public void MenuControles()
    {
        //Permite abrir el menú de controles mediante un botón
        GameManager.Instance.AbrirMenuControles();
    }
}
