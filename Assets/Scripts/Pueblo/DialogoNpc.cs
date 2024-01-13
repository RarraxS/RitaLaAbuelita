using UnityEngine;


[CreateAssetMenu(menuName = "Diálogos/Diálogos con NPC")]
public class DialogoNpc : ScriptableObject
{
    //Las variables que debemos rellenar para los diálogos.
    //Estos son tanto los diálogos de cada personaje como el número total de diálogos para saber cuando cerrar el 
    //menú de diálogo, como el numero de NPC que es, para así setear el animator con la cabeza del NPC correspondiente
    //y también marcamos si es Rita la que inicia la conversación o no
    public string[] dialogosRita, dialogosNpc;
    public int numTotalDialogos, numNpc;
    public bool ritaHablaPrimero;
}
