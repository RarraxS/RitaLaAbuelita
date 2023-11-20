using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Diálogos/Diálogos con NPC")]
public class DialogoNpc : ScriptableObject
{
    public GameObject npc;
    public string dialogo;
    public GameObject canvasDialogo;
}
