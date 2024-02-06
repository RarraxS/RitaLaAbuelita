using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonMouseOver : MonoBehaviour
{
    public Indicador indicador;
    public string toolTip;

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    indicador.textIndcador.text = string.Empty;
    //}

    //public void OnPointerMove(PointerEventData eventData)
    //{
    //    indicador.textIndcador.text = toolTip;
    //}

    //void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    //{
    //    indicador.textIndcador.text = toolTip;
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject != null)
        {
            if (EventSystem.current.currentSelectedGameObject == gameObject)
                indicador.textIndcador.text = toolTip;
        //    else if (EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Button>() == null)
        //        indicador.textIndcador.text = string.Empty;
        }
    }
}
