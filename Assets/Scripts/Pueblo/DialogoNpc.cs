using UnityEngine;


[CreateAssetMenu(menuName = "Di�logos/Di�logos con NPC")]
public class DialogoNpc : ScriptableObject
{
    //Las variables que debemos rellenar para los di�logos.
    //Estos son tanto los di�logos de cada personaje como el n�mero total de di�logos para saber cuando cerrar el 
    //men� de di�logo, como el numero de NPC que es, para as� setear el animator con la cabeza del NPC correspondiente
    //y tambi�n marcamos si es Rita la que inicia la conversaci�n o no
    public string[] dialogosRita, dialogosNpc;
    public int numTotalDialogos, numNpc;
    public bool ritaHablaPrimero;
}
