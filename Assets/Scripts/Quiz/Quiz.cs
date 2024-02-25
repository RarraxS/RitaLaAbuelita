using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quiz : MonoBehaviour
{
    [SerializeField] private List<Preguntas> preguntas = null;
    private List<Preguntas> backup = null;
    private void Awake()
    {
        backup = preguntas.ToList();
    }

    public Preguntas GetRandom(bool remove = true)
    {
        if (preguntas.Count <= 0)
        {
            RestoreBackup();
        }

        int index = Random.Range(0, preguntas.Count);
        if(!remove )
        {
            return preguntas[index];
        }
        Preguntas pregunta = preguntas[index];
        preguntas.RemoveAt(index);

        return pregunta;
    }
    private void RestoreBackup()
    {
        preguntas = backup.ToList();
    }
}

