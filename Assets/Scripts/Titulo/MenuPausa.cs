using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private float timerPausa = 0.55f;
    public bool salidaPausa = false;
    private bool entradoPausa = false;

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
            timerPausa -= Time.deltaTime;

            if (timerPausa <= 0)
            {
                animator.SetInteger("menuPausa", 1);
                timerPausa = 0.55f;
            }
        }

        if (GameManager.Instance.canvasPausa.activeSelf && salidaPausa == true)
        {
            if (entradoPausa == false)
            {
                animator.SetInteger("menuPausa", 2);
                entradoPausa = true;
            }

            timerPausa -= Time.deltaTime;

            if (timerPausa <= 0)
            {
                timerPausa = 0.55f;
                GameManager.Instance.canvasPausa.SetActive(false);
                entradoPausa = false;

                if (GameManager.Instance.escena == "Pueblo" || GameManager.Instance.escena == "CasaRita")
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
        salidaPausa = true;
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
