using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlesSalir : MonoBehaviour
{
    public void MenuControles()
    {
        GameManager.Instance.AbrirMenuControles();
    }

    public void VolverPueblo()
    {
        SceneManager.LoadScene("Pueblo");
    }
}
