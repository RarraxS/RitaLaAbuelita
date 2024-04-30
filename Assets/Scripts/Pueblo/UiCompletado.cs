using UnityEngine;
using UnityEngine.UI;

public class UiCompletado : MonoBehaviour
{
    [SerializeField] private GameObject toggleQuiz, toggleCocinar;
    [SerializeField] private GameObject[] toggleBuscaObjetos;

    // Start is called before the first frame update
    void Awake()
    {
        toggleQuiz.SetActive(false);

        for (int i = 0; i < toggleBuscaObjetos.Length; i++)
        {
            toggleBuscaObjetos[i].SetActive(false);
        }

        toggleCocinar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarUI();
    }

    private void ActualizarUI()
    {
        //Actualiza el estado del quiz --------------------------------------------------------

        if (GameManager.Instance.quizCompletado == true)
        {
            toggleQuiz.SetActive(true);
        }

        else
        {
            toggleQuiz.SetActive(false);
        }
        //-------------------------------------------------------------------------------------

        //Actualiza el estado del busca objetos -----------------------------------------------

        if (GameManager.Instance.buscaObjetosCompletado == true)
        {
            for (int i = 0; i < toggleBuscaObjetos.Length; i++)
            {
                toggleBuscaObjetos[i].SetActive(true);
            }
        }

        else
        {
            for (int i = 0; i < toggleBuscaObjetos.Length; i++)
            {
                toggleBuscaObjetos[i].SetActive(false);
            }
        }
        //-------------------------------------------------------------------------------------

        //Actualiza el estado del cocinar -----------------------------------------------------

        if (GameManager.Instance.cocinarCompletado == true)
        {
            toggleCocinar.SetActive(true);
        }

        else
        {
            toggleCocinar.SetActive(false);
        }
        //-------------------------------------------------------------------------------------
    }
}
