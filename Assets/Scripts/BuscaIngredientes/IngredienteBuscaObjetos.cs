using System.Collections;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class IngredienteBuscaObjetos : MonoBehaviour
{
    [SerializeField] private int[] _velocidad;
    [SerializeField] float timerPausa;
    [SerializeField] private int _parpadeos;
    public TMP_Text textTiempo;
    private Color _colorDeFallo;
    SpriteRenderer sr;

    public IngredienteBuscaObjetos ingrediente;

    private Vector2 _direction;

    float _timerPausaInicial, _timepoPorParpadeo, _tiempoParpadeo;
    int _numParpadeos;
    bool _spriteOn = true, pulsable = true;

    //Raycast
    RaycastHit2D informacionRaycast;
    public float distanciaRaycast;
    [SerializeField] LayerMask mascara;
    public Vector3 direccionRaycast = new Vector3(0, 0, 1);

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        _timerPausaInicial = timerPausa;

        _numParpadeos = _parpadeos * 2;

        _timepoPorParpadeo = _timerPausaInicial / _parpadeos;

        RandomizarPosicion();
    }

    void Update()
    {
        transform.Translate(Time.deltaTime * _velocidad[MinijuegoManagerBuscaIngredientes.Instance.Nivel] * _direction);

        CorregirPosicion();

    }
    

    void OnMouseDown()
    {
        if (tag == "Buscando" && MinijuegoManagerBuscaIngredientes.Instance.jugar == true)
        {
            MinijuegoManagerBuscaIngredientes.Instance.timer += MinijuegoManagerBuscaIngredientes.Instance.tiempoGanadoPorAcertar;
            MinijuegoManagerBuscaIngredientes.Instance.DestruirNivelEnabled = true;
            MinijuegoManagerBuscaIngredientes.Instance.timerEsperaEnabled = true;
            GameManager.Instance.SonidoPlay(15);
            StartCoroutine(Acertar());
        }

        if (tag == "No buscando" && MinijuegoManagerBuscaIngredientes.Instance.jugar == true)
        {
            MinijuegoManagerBuscaIngredientes.Instance.timer -= MinijuegoManagerBuscaIngredientes.Instance.tiempoPerdidoPorFallar;
            GameManager.Instance.SonidoPlay(16);
            StartCoroutine(Fallar());
        }
    }

    void RandomizarPosicion()
    {
        Vector2 randomCircle = Random.insideUnitCircle;
        Vector3 randomPosition = new(randomCircle.x, randomCircle.y, 0);
        _direction = (randomPosition - transform.position).normalized;
    }

    void CorregirPosicion()
    {
        if (transform.position.x <= MinijuegoManagerBuscaIngredientes.Instance.minimoValorEjeX ||
            transform.position.x >= MinijuegoManagerBuscaIngredientes.Instance.maximoValorEjeX ||
            transform.position.y <= MinijuegoManagerBuscaIngredientes.Instance.minimoValorEjeY ||
            transform.position.y >= MinijuegoManagerBuscaIngredientes.Instance.maximoValorEjeY)
        {
            RandomizarPosicion();
        }
    }

    IEnumerator Acertar()
    {
        _direction *= 0;
        while (transform.localScale.x < 0.1f)
        {
            transform.localScale += new Vector3(0.03f, 0.03f, 0.03f) * Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator Fallar()
    {
        if (pulsable == true)
        {
            MinijuegoManagerBuscaIngredientes.Instance.jugar = false;

            _colorDeFallo = textTiempo.GetComponent<TextMeshProUGUI>().color;
            textTiempo.GetComponent<TextMeshProUGUI>().color = Color.red;
            Vector3 scaleOfText = textTiempo.GetComponent<RectTransform>().localScale;
            textTiempo.GetComponent<RectTransform>().localScale = new Vector3(1.25f, 1.25f, 1.25f);
            _numParpadeos = _parpadeos * 2;

            while (_numParpadeos > 0)
            {
                _tiempoParpadeo -= Time.deltaTime;

                if (_tiempoParpadeo <= 0)
                {
                    _numParpadeos--;
                    switch (_spriteOn)
                    {
                        case true:
                            sr.color = new Color(255, 255, 255, 0);
                            _spriteOn = false;
                            break;

                        case false:
                            sr.color = new Color(255, 255, 255, 255);
                            _spriteOn = true;
                            break;
                    }
                    _tiempoParpadeo = _timepoPorParpadeo;
                }
                yield return null;
            }

            MinijuegoManagerBuscaIngredientes.Instance.jugar = true;
            timerPausa = _timerPausaInicial;
            textTiempo.GetComponent<TextMeshProUGUI>().color = Color.black;
            textTiempo.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            sr.color = new Color(255, 255, 255, 255);
        }

    }
}
