using System.Collections;
using TMPro;
using UnityEngine;

public class IngredienteBuscaObjetos : MonoBehaviour
{
    [SerializeField] private int[] _velocidad;
    [SerializeField] private float timerPausa;
    [SerializeField] private int _parpadeos;
    public TMP_Text textTiempo;
    private Color _colorDeFallo;
    private SpriteRenderer sr;

    public IngredienteBuscaObjetos ingrediente;

    private Vector2 _direction;

    private float _timerPausaInicial, _timepoPorParpadeo, _tiempoParpadeo;
    private int _numParpadeos;
    private bool _spriteOn = true, pulsable = true;

    private void Start()
    {
        //Se setean las variables que se van a usar, se establece que el número de parpadeos
        //es del doble de los estipulado, dado que se cuenta aparición y desaparición, y se 
        //randomiza la posición del objeto

        sr = GetComponent<SpriteRenderer>();

        _timerPausaInicial = timerPausa;

        _numParpadeos = _parpadeos * 2;

        _timepoPorParpadeo = _timerPausaInicial / _parpadeos;

        RandomizarPosicion();
    }

    private void Update()
    {
        //Se mueve el objeto en una dirección random, y se comprueba si se ha chocado con alguno de los bordes,
        //si ha sido así, se cambia la dirección a la que se está moviendo la pieza

        transform.Translate(Time.deltaTime * _velocidad[MinijuegoManagerBuscaIngredientes.Instance.Nivel] * _direction);

        CorregirPosicion();
    }
    

    private void OnMouseDown()
    {
        //Si se acierta se le suma al temporizador más tiempo, se destruye el nivel y suena el sonido de acertar
        if (tag == "Buscando" && MinijuegoManagerBuscaIngredientes.Instance.jugar == true)
        {
            MinijuegoManagerBuscaIngredientes.Instance.timer += MinijuegoManagerBuscaIngredientes.Instance.tiempoGanadoPorAcertar;
            MinijuegoManagerBuscaIngredientes.Instance.DestruirNivelEnabled = true;
            MinijuegoManagerBuscaIngredientes.Instance.timerEsperaEnabled = true;
            GameManager.Instance.SonidoPlay(5);
            StartCoroutine(Acertar());
        }

        //Si se falla se le resta al temporizador una cantidad de tiempo, y suena el sonido de fallar
        if (tag == "No buscando" && MinijuegoManagerBuscaIngredientes.Instance.jugar == true)
        {
            MinijuegoManagerBuscaIngredientes.Instance.timer -= MinijuegoManagerBuscaIngredientes.Instance.tiempoPerdidoPorFallar;
            GameManager.Instance.SonidoPlay(6);
            StartCoroutine(Fallar());
        }
    }

    private void RandomizarPosicion()
    {
        //Randomiza la posición
        Vector2 randomCircle = Random.insideUnitCircle;
        Vector3 randomPosition = new(randomCircle.x, randomCircle.y, 0);
        _direction = (randomPosition - transform.position).normalized;
    }

    private void CorregirPosicion()
    {
        //Comprueba si se han sobrepasado los bordes establecidos y si así ha
        //sido, se vuelve a randomizar la posición hacia la que se va a mover
        if (transform.position.x <= MinijuegoManagerBuscaIngredientes.Instance.minimoValorEjeX ||
            transform.position.x >= MinijuegoManagerBuscaIngredientes.Instance.maximoValorEjeX ||
            transform.position.y <= MinijuegoManagerBuscaIngredientes.Instance.minimoValorEjeY ||
            transform.position.y >= MinijuegoManagerBuscaIngredientes.Instance.maximoValorEjeY)
        {
            RandomizarPosicion();
        }
    }

    private IEnumerator Acertar()
    {
        //Si se acierta el objeto acierto se hace más grande frame a frame
        while (transform.localScale.x < 0.1f)
        {
            _direction *= 0;
            transform.localScale += new Vector3(0.03f, 0.03f, 0.03f) * Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator Fallar()
    {
        //Si se falla  el objeto pulsado se pone a parpadear y el texto de
        //tiempo se hace más grande y se pone rojo por un tiempo establecido
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
