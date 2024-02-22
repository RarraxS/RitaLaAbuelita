using UnityEngine;

public class MenuSalir : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private float timerSalir = 0.45f;
    public bool salidaSalir = false;
    private bool entradoSalir = false;

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
        if (GameManager.Instance.canvasSalir.activeSelf && !(animator.GetInteger("menuSalir") == 1))
        {
            timerSalir -= Time.deltaTime;

            if (timerSalir <= 0 && animator.GetInteger("menuSalir") == 0)
            {
                animator.SetInteger("menuSalir", 1);
                timerSalir = 0.45f;
            }

            if (timerSalir <= 0 && animator.GetInteger("menuSalir") == 2)
            {
                timerSalir = 0.45f;
                GameManager.Instance.canvasSalir.SetActive(false);
                entradoSalir = false;
                salidaSalir = false;
            }
        }

        if (GameManager.Instance.canvasSalir.activeSelf && salidaSalir == true)
        {
            if (entradoSalir == false)
            {
                animator.SetInteger("menuSalir", 2);
                entradoSalir = true;
            }
        }
    }
}
