using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonGanarJuego : MonoBehaviour
{
    public void VolverTitulo()
    {
        MenuPausa.Instance.Reiniciar();
    }
}
