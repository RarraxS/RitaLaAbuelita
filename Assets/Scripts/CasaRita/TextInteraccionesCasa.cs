using UnityEngine;

public class TextInteraccionesCasa : MonoBehaviour
{
    [SerializeField] private Transform targetObjectRita;  // Referencia al GameObject que seguirá el objeto de texto.
    [SerializeField] private RectTransform textTransformEspacio; //Movimiento Texto
    [SerializeField] private Vector3 VerticalOffset; //Posicion exta

    [SerializeField] GameObject canvasSalirInteraccion;

    string _zona;

    string cocina_ = "Encimera";
    string casa_ = "Alfombra";

    void Start()
    {
        canvasSalirInteraccion.SetActive(false);
    }
    void Update()
    {
        _zona = string.Empty;
        Enter();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _zona = collision.tag;
        Enter();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _zona = string.Empty;
        Enter();
    }

    public void Enter()
    {
        if (_zona != string.Empty)
        {
            if(_zona== cocina_ || _zona==casa_)
            {
                canvasSalirInteraccion.SetActive(true);

                if (targetObjectRita != null)
                {
                    // Calcula la posición a la que el texto debe seguir al objeto.
                    Vector3 targetPosition = Camera.main.WorldToScreenPoint(targetObjectRita.position);

                    // Asigna la nueva posición al objeto de texto.
                    textTransformEspacio.position = targetPosition + VerticalOffset;
                }
            }
        }
        else
            canvasSalirInteraccion.SetActive(false);
    }
}

