using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))] //Obligo al objeto ser una imagen y un botón
[RequireComponent(typeof(Image))]
public class BotonOpcion : MonoBehaviour
{
    private Text texto = null;
    private Button boton = null;
    private Image imagen = null;
    private Color colorOGimagen = Color.black;
    public Opciones Opciones { get;  set; }
    private void Awake()
    {
        boton = GetComponent<Button>();
        imagen = GetComponent<Image>();
        texto = transform.GetChild(0).GetComponent<Text>();
        colorOGimagen = imagen.color;
    }
    public void Construct(Opciones opciones, Action<BotonOpcion> callback)
    {
        texto.text = opciones.text;
        boton.enabled = true;
        imagen.color = colorOGimagen;
        boton.onClick.RemoveAllListeners();

        Opciones = opciones;

        boton.onClick.AddListener(delegate
        {
            callback(this); // Cuando selecionemos esta opcion le estamos mandando este a opciones para ver si es la correcta
        });
    }

    public void SetColor(Color color)
    {
        boton.enabled = false;
        imagen.color = color;
    }
}
