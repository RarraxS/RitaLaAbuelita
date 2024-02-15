using UnityEngine;

[CreateAssetMenu(menuName = "Busca Objetos/Distribución")]
public class ControladorSprites : ScriptableObject
{
    //Estas son los sprites que se van a utilizar en cada nivel
    [SerializeField] private Sprite[] sprite;
}