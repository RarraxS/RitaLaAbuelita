using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class Indicador : MonoBehaviour
{
    public TMP_Text textIndcador;

    void Update()
    {
        if (GameManager.Instance.permitirTextIndicador == true)
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

        else
        {
            return;
        }

    }
}
