using UnityEngine;

public class MenuSalir : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private float timerControles = 0.45f;
    public bool salidaControles = false;
    private bool entradoControles = false;

    private static MenuSalir instance;
    public static MenuSalir Instance
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
        if (GameManager.Instance.canvasControles.activeSelf && !(animator.GetInteger("menuControles") == 1))
        {
            timerControles -= Time.deltaTime;

            if (timerControles <= 0 && animator.GetInteger("menuSalir") == 0)
            {
                animator.SetInteger("menuSalir", 1);
                timerControles = 0.55f;
            }

            if (timerControles <= 0 && animator.GetInteger("menuSalir") == 2)
            {
                timerControles = 0.55f;
                GameManager.Instance.canvasControles.SetActive(false);
                entradoControles = false;
                salidaControles = false;
            }
        }

        if (GameManager.Instance.canvasControles.activeSelf && salidaControles == true)
        {
            if (entradoControles == false)
            {
                animator.SetInteger("menuSalir", 2);
                entradoControles = true;
            }
        }
    }
}
