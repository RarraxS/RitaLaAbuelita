using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Botones : MonoBehaviour
{
    private static Botones instance;
    public static Botones Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        instance = this;
    }

    public void Destruccion()
    {
        Destroy(gameObject);
    }
}
