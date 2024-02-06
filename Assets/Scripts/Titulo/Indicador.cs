using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using UnityEngine.EventSystems;

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

        textIndcador.text = string.Empty;

        // Check if the mouse was clicked over a UI element
        if (EventSystem.current.IsPointerOverGameObject())
        {
            PointerEventData pe = new PointerEventData(EventSystem.current);

            pe.position = Input.mousePosition;
            List<RaycastResult> hits = new List<RaycastResult>();

            EventSystem.current.RaycastAll(pe, hits);

            foreach (RaycastResult hit in hits)
            {
                if (hit.gameObject.CompareTag("toolTip"))
                {
                    textIndcador.text = hit.gameObject.name;
                }
            }
        }

    }

    private void MostrarIndicador()
    {
        //Vector3 targetPosition = Camera.main.WorldToScreenPoint(targetObject.position);
    }
}
