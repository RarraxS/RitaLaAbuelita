using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiDialogo : MonoBehaviour
{
    [SerializeField] ScriptableObject[] interaccion;
    [SerializeField] TMP_Text textRita, textNpc;

    [SerializeField] Animator animator;

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
        AccederInteractuable();
    }

    void AccederInteractuable()
    {
        for (int i = 0; i < interaccion.Length; i++)
        {
            if (PuebloManager.Instance.collidedObject)
            {


                if (PuebloManager.Instance.collidedObject.name == interaccion[i].name)
                {
                    string DialogoNpc = ((DialogoNpc)interaccion[i]).dialogoNpc;
                    string DialogoRita = ((DialogoNpc)interaccion[i]).dialogoRita;
                    int numNpc = ((DialogoNpc)interaccion[i]).numNpc;

                    textNpc.text = DialogoNpc;
                    textRita.text = DialogoRita;
                    animator.SetInteger("numNpc", numNpc);
                    Debug.Log(numNpc);
                }
            }
        }
    }
}
