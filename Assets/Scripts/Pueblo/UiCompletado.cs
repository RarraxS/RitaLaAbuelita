using UnityEngine;
using UnityEngine.UI;

public class UiCompletado : MonoBehaviour
{
    [SerializeField] private Toggle toggleQuiz, toggleCocinar;
    [SerializeField] private Toggle[] toggleBuscaObjetos;

    // Start is called before the first frame update
    void Awake()
    {
        toggleQuiz.isOn = false;

        for (int i = 0; i < toggleBuscaObjetos.Length; i++)
        {
            toggleBuscaObjetos[i].isOn = false;
        }

        toggleCocinar.isOn = false;
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
            toggleQuiz.isOn = true;
        }

        else
        {
            toggleQuiz.isOn = false;
        }
        //-------------------------------------------------------------------------------------

        //Actualiza el estado del busca objetos -----------------------------------------------

        if (GameManager.Instance.buscaObjetosCompletado == true)
        {
            for (int i = 0; i < toggleBuscaObjetos.Length; i++)
            {
                toggleBuscaObjetos[i].isOn = true;
            }
        }

        else
        {
            for (int i = 0; i < toggleBuscaObjetos.Length; i++)
            {
                toggleBuscaObjetos[i].isOn = false;
            }
        }
        //-------------------------------------------------------------------------------------

        //Actualiza el estado del cocinar -----------------------------------------------------

        if (GameManager.Instance.cocinarCompletado == true)
        {
            toggleCocinar.isOn = true;
        }

        else
        {
            toggleCocinar.isOn = false;
        }
        //-------------------------------------------------------------------------------------
    }
}
