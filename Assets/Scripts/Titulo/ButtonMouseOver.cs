using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMouseOver : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    public Indicador indicador;
    public string toolTip;

    public void OnPointerExit(PointerEventData eventData)
    {
        indicador.textIndcador.text = string.Empty;
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        indicador.textIndcador.text = toolTip;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
