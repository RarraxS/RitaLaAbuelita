using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
<<<<<<< HEAD
    public string controles;
    public bool permitirAbrirMenuControles = true;

    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this);
=======
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void MinijuegoPulsarIngredientes()
    {
        SceneManager.LoadScene("PulsarIngredientes");
>>>>>>> parent of f50ee36 (V 0.1)
    }
}
