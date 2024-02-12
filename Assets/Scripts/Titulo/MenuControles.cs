using UnityEngine;

public class MenuControles : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private float timer = 0.55f;
    public bool salida = false;
    private bool entrado = false;

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
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                animator.SetInteger("menuControles", 1);
                timer = 0.55f;
            }
        }

        if (GameManager.Instance.canvasControles.activeSelf && salida == true)
        {
            if (entrado == false)
            {
                animator.SetInteger("menuControles", 2);
                entrado = true;
            }

            timer -= Time.deltaTime;
            Debug.Log(timer);

            if (timer <= 0)
            {
                timer = 0.55f;
                GameManager.Instance.canvasControles.SetActive(false);
                entrado = false;
                salida = false;
            }
        }
    }
}
