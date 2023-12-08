using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class CargaManager : MonoBehaviour
{
    float timerEspera = 2.1f;

    private static CargaManager instance;
    public static CargaManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        timerEspera -= Time.deltaTime;

        if (timerEspera <= 0)
        {
            SceneManager.LoadScene(GameManager.Instance.escena);
        }
    }

}