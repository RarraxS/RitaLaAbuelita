using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiDialogo : MonoBehaviour
{
    public Animator animator;

    private static UiDialogo instance;
    public static UiDialogo Instance
    {
        get { return instance; }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
}
