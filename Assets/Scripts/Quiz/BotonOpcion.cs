using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class BotonOpcion : MonoBehaviour
{
    private TMP_Text texto = null;
    private Button boton = null;
    private Image imagen = null;
    private Color colorOGimagen = Color.black;
    public Opciones Opciones { get;  set; }
    private void Awake()
    {
        boton = GetComponent<Button>();
        imagen = GetComponent<Image>();
        texto = transform.GetChild(0).GetComponent<TMP_Text>();
        colorOGimagen = imagen.color;
    }
    public void Construct(Opciones opciones, Action<BotonOpcion> callback)
    {
        texto.text = opciones.text;
        boton.onClick.RemoveAllListeners();
        boton.enabled = true;
        imagen.color = colorOGimagen;

        Opciones = opciones;
    }

    public void SetColor(Color color)
    {
        boton.enabled = false;
        imagen.color = color;
    }
}
