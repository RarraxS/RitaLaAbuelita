using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnimaticaFinal : MonoBehaviour
{
    [SerializeField] GameObject canvasAnimatica1;
    [SerializeField] GameObject canvasVictoria;
    void Start()
    {
        canvasAnimatica1.SetActive(true);
        canvasVictoria.SetActive(false);
    }
    public void Animatica2()
    {
        canvasAnimatica1.SetActive(false);
        canvasVictoria.SetActive(true);
        GameManager.Instance.SonidoPlay(0);
    }
}
   