using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Animatica : MonoBehaviour
{
    [SerializeField] GameObject canvasAnimatica1;
    [SerializeField] GameObject canvasAnimatica2;
    [SerializeField] GameObject canvasAnimatica3;
    [SerializeField] GameObject canvasAnimatica4;
    void Start()
    {
        canvasAnimatica1.SetActive(true);
        canvasAnimatica2.SetActive(false);
        canvasAnimatica3.SetActive(false);
        canvasAnimatica4.SetActive(false);
    }
    public void Animatica2()
    {
        canvasAnimatica1.SetActive(false);
        canvasAnimatica2.SetActive(true);
        GameManager.Instance.SonidoPlay(0);
    }
    public void Animatica3()
    {
        canvasAnimatica2.SetActive(false);
        canvasAnimatica3.SetActive(true);
        GameManager.Instance.SonidoPlay(0);
    }

    public void Animatica4()
    {
        canvasAnimatica3.SetActive(false);
        canvasAnimatica4.SetActive(true);
        GameManager.Instance.SonidoPlay(0);
    }

    public void Fin() 
    {
        GameManager.Instance.escena = "CasaRita";
        SceneManager.LoadScene("PantallaCarga");
    }
}
