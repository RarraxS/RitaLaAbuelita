using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FondoInicio : MonoBehaviour
{
    float timer = 1.75f;
    public bool timerActivado = false;

    public Animator animator;

    private static FondoInicio instance;
    public static FondoInicio Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Timer();
    }

    void Timer()
    {
        if(timerActivado == true)
        {
            timer -= Time.deltaTime;
        }

        if(timer <= 0)
        {
            SceneManager.LoadScene("PantallaCarga");
            GameManager.Instance.escena = "Pueblo";
        }
    }
}
