using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngredienteBuscaObjetos : MonoBehaviour
{
    [SerializeField] private int[] _velocidad;
    [SerializeField] float timerPausa;
    [SerializeField] private int _parpadeos;
    public TMP_Text textTiempo;
    private Color _colorDeFallo;
    SpriteRenderer sr;

    private Vector3 _direction;

    float _timerPausaInicial, _timepoPorParpadeo, _tiempoParpadeo;
    int _numParpadeos;
    bool _spriteOn = true, fallado = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        _timerPausaInicial = timerPausa;

        _numParpadeos = _parpadeos * 2;

        _timepoPorParpadeo = _timerPausaInicial / _parpadeos;

        _tiempoParpadeo = _timepoPorParpadeo;

        RandomizarPosicion();
    }

    void Update()
    {
        transform.Translate(Time.deltaTime * _velocidad[MinijuegoManagerBuscaIngredientes.Instance.Nivel] * _direction);

        CorregirPosicion();

        Fallar();
    }
    

    void OnMouseDown()
    {
        if (tag == "Buscando" && MinijuegoManagerBuscaIngredientes.Instance.jugar == true)
        {
            MinijuegoManagerBuscaIngredientes.Instance.timer += MinijuegoManagerBuscaIngredientes.Instance.tiempoGanadoPorAcertar;
            MinijuegoManagerBuscaIngredientes.Instance.DestruirNivelEnabled = true;
            MinijuegoManagerBuscaIngredientes.Instance.timerEsperaEnabled = true;
        }

        if (tag == "No buscando" && MinijuegoManagerBuscaIngredientes.Instance.jugar == true)
        {
            MinijuegoManagerBuscaIngredientes.Instance.timer -= MinijuegoManagerBuscaIngredientes.Instance.tiempoPerdidoPorFallar;
            fallado = true;
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

    void Fallar()
    {
        if (fallado == true)
        {
            MinijuegoManagerBuscaIngredientes.Instance.jugar = false;

            timerPausa -= Time.deltaTime;

            _colorDeFallo = textTiempo.GetComponent<TextMeshProUGUI>().color;
            textTiempo.GetComponent<TextMeshProUGUI>().color = Color.red;
            Vector3 scaleOfText = textTiempo.GetComponent<RectTransform>().localScale;

            for (int i = 0; i < _numParpadeos; i++)
            {
                _tiempoParpadeo -= Time.deltaTime;

                if (_tiempoParpadeo <= 0)
                {
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
            }

            if (timerPausa <= 0)
            {
                MinijuegoManagerBuscaIngredientes.Instance.jugar = true;
                timerPausa = _timerPausaInicial;
                fallado = false;
                sr.color = new Color(255, 255, 255, 255);
            }
        }
    }
}
