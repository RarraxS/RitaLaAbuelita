using UnityEngine;

public class TextInteraccionesCasa : MonoBehaviour
{
    [SerializeField] private Transform targetObjectRita;  // Referencia al GameObject que seguirá el objeto de texto.
    [SerializeField] private RectTransform textTransformEspacio; //Movimiento Texto
    [SerializeField] private Vector3 VerticalOffset; //Posicion exta

    [SerializeField] GameObject canvasInteraccion;

    string _zona;

    string cocina_ = "Cocinar";
    string casa_ = "Casa";

    void Start()
    {
        canvasInteraccion.SetActive(false);
    }
    void Update()
    {
        _zona = string.Empty;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _zona = collision.tag;
        Enter();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _zona = string.Empty;
    }

    public void Enter()
    {
        if (_zona != string.Empty)
        {
            if(_zona== cocina_ || _zona==casa_)
            {
                canvasInteraccion.SetActive(true);

                if (targetObjectRita != null)
                {
                    // Calcula la posición a la que el texto debe seguir al objeto.
                    Vector3 targetPosition = Camera.main.WorldToScreenPoint(targetObjectRita.position);

                    // Asigna la nueva posición al objeto de texto.
                    textTransformEspacio.position = targetPosition + VerticalOffset;
                }
            }
        }
    }
}

