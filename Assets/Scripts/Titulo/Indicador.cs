using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Indicador : MonoBehaviour
{
    public TMP_Text textIndcador;
    //[SerializeField] mouse 

    void Start()
    {
        
    }

    void Update()
    {
        textIndcador.rectTransform.anchoredPosition = 
        Input.mousePosition / transform.localScale.x;
    }

    private void MostrarIndicador()
    {
        //Vector3 targetPosition = Camera.main.WorldToScreenPoint(targetObject.position);
    }
}
