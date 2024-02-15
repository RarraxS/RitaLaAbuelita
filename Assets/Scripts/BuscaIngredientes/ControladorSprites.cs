using UnityEngine;

[CreateAssetMenu(menuName = "Busca Objetos/Distribuci�n")]
public class ControladorSprites : ScriptableObject
{
    //Estas son los sprites que se van a utilizar en cada nivel
    [SerializeField] private Sprite[] sprite;
}