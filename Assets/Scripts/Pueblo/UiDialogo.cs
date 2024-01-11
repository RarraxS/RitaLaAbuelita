using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UiDialogo : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] interaccion;


    //-------------------------------------------------------------------------------
    //Sistema de diálogos
    [SerializeField] private TMP_Text textRita, textNpc;
    private int interaccionActual, interaccionActualRita, interaccionActualNPC;
    private bool turnoRita;

    private int numInteraccionesTotales;

    public bool accesoInicial = false;
    private bool ritaPrimero;
    private int numNpc;
    private string DialogoNpc, DialogoRita;





    [SerializeField] private float descansoEntreLetras = 0.1f;
    private float temporizador = 0f;
    private string textoImprimir;
    private string textoActualRita, textoActualNPC;
    private int letraActual;

    //-------------------------------------------------------------------------------

    [SerializeField] private Animator animator;

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
        DialogoMultiple();
    }

    private void DialogoMultiple()
    {
        AccederNPC();
        Continuar();
    }


    public void InicializarDialogos()
    {
        if (ritaPrimero == true && accesoInicial == false)
        {
            interaccionActualRita = 1;
            interaccionActualNPC = 0;
            turnoRita = false;
        }

        else if (ritaPrimero == false && accesoInicial == false)
        {
            interaccionActualRita = 0;
            interaccionActualNPC = 1;
            turnoRita = true;
        }
    }

    private void AccederNPC()
    {
        for (int i = 0; i < interaccion.Length; i++)
        {
            if (PuebloManager.Instance.collidedObject.name == interaccion[i].name)
            {
                //Aquí sacamos estas variables antes para tenerlas listas antes del bucle for
                int numNpc = ((DialogoNpc)interaccion[i]).numNpc;


                ritaPrimero = ((DialogoNpc)interaccion[i]).ritaHablaPrimero;
                numInteraccionesTotales = ((DialogoNpc)interaccion[i]).numTotalDialogos;
                accesoInicial = true;

                //Seteamos el animator antes de entrar al bucle for para que no consuma recursos cada frame
                animator.SetInteger("numNpc", numNpc);
                //Debug.Log(numNpc);


                string DialogoNpc = ((DialogoNpc)interaccion[i]).dialogosNpc[interaccionActualRita];
                string DialogoRita = ((DialogoNpc)interaccion[i]).dialogosRita[interaccionActualNPC];

                textRita.text = DialogoRita;
                textNpc.text = DialogoNpc;
            }
        }
    }
    
    private void Continuar()
    {
        if ((Rita.Instance.canvasDialogo.activeSelf && (Input.GetKeyDown(KeyCode.U) && GameManager.Instance.controles == "zurdo")) ||
            (Rita.Instance.canvasDialogo.activeSelf && (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.controles == "diestro")))
        {
            if (turnoRita == true)
            {
                interaccionActualRita++;
                interaccionActual++;
            }
            
            if (turnoRita == false)
            {
                interaccionActualNPC++;
                interaccionActual++;
            }

            turnoRita = !turnoRita;

            Debug.Log("InterAct " + interaccionActual);
            if (interaccionActual > numInteraccionesTotales)
            {
                Rita.Instance.canvasDialogo.SetActive(false);
                interaccionActual = 0;
                interaccionActualRita = 0;
                interaccionActualNPC = 0;
                Rita.Instance.permitirMovimiento = true;
            }
        }
    }
}