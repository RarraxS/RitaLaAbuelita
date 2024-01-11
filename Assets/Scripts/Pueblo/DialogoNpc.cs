using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Di�logos/Di�logos con NPC")]
public class DialogoNpc : ScriptableObject
{
    public string[] dialogosRita, dialogosNpc;
    public int numTotalDialogos, numNpc;
    public bool ritaHablaPrimero;
}
