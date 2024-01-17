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
    //-------------------------------------------------------------------------------

    [SerializeField] private Animator animator;

    private static UiDialogo instance;
    public static UiDialogo Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        DialogoMultiple();
    }

    private void DialogoMultiple()
    {
        AccederNPC();
        Continuar();
    }

    private void AccederNPC()
    {
        //Comprobamos si el objeto colisionado coincide con alguno de los Dialogos que hay creados y
        //almecenamos sus datos en variables para usarlas más tarde
        for (int i = 0; i < interaccion.Length; i++)
        {
            if (PuebloManager.Instance.collidedObject.name == interaccion[i].name)
            {
                int numNpc = ((DialogoNpc)interaccion[i]).numNpc;


                ritaPrimero = ((DialogoNpc)interaccion[i]).ritaHablaPrimero;
                numInteraccionesTotales = ((DialogoNpc)interaccion[i]).numTotalDialogos;

                //Se comprueba el valor de "ritaPrimero" y dependiendo de su valor ajustamos parametros,
                //le metemos una variable de ocntención llamada "accesoInicial" que después setearemos a
                //"true" para que no vuelva a setear los valores hasta la proxima vez que iniciemos un
                //diálogo con un NPC la cual es seteada a "false" otra vez desde el spript de Rita
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

                accesoInicial = true;

                animator.SetInteger("numNpc", numNpc);

                //Esta variable es la que va a controlar a que diálogos accedemos de cada personaje y como tiene que acceder
                //a las siguientes posiciones del array hacemos que se actualice cada frame y lo mostramos por pantalla
                string DialogoNpc = ((DialogoNpc)interaccion[i]).dialogosNpc[interaccionActualNPC];
                string DialogoRita = ((DialogoNpc)interaccion[i]).dialogosRita[interaccionActualRita];

                textRita.text = DialogoRita;
                textNpc.text = DialogoNpc;
            }
        }
    }

    private void Continuar()
    {
        //Hacemos que al pulsar la tecla de interacción contador de diálogos aumenta y la conversación avanza,
        //tocandole ahora hablar al otro personaje.
        if (Rita.Instance.canvasDialogo.activeSelf && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
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

            //Si el contador ya ha llegado al número máximoo en esa conversación setea todo
            //a 0, se cierra el menúu de conversación y le permite al jugador volver a moverse 
            if (interaccionActual >= numInteraccionesTotales)
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