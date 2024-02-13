using UnityEngine;

public class MenuControles : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private float timerControles = 0.55f;
    public bool salidaControles = false;
    private bool entradoControles = false;

    private static MenuControles instance;
    public static MenuControles Instance
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
        if (GameManager.Instance.canvasControles.activeSelf && animator.GetInteger("menuControles") == 0)
        {
            timerControles -= Time.deltaTime;

            if (timerControles <= 0)
            {
                animator.SetInteger("menuControles", 1);
                timerControles = 0.55f;
            }
        }

        if (GameManager.Instance.canvasControles.activeSelf && salidaControles == true)
        {
            if (entradoControles == false)
            {
                animator.SetInteger("menuControles", 2);
                entradoControles = true;
            }

            timerControles -= Time.deltaTime;

            if (timerControles <= 0)
            {
                timerControles = 0.55f;
                GameManager.Instance.canvasControles.SetActive(false);
                entradoControles = false;
                salidaControles = false;
            }
        }
    }
}
