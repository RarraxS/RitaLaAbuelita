using UnityEngine;

public class LimitadorFPS : MonoBehaviour
{
    private int limiteFPS = 30;

    void Start()
    {
        Application.targetFrameRate= limiteFPS;
    }
}