using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private TMP_Text pregunta = null;
    [SerializeField] private List<BotonOpcion> botones = null;

    public void Construct(Preguntas preguntas, Action<BotonOpcion> callback)
    {
        pregunta.text = preguntas.text;

        for(int i = 0; i < botones.Count; i++)
        {
            botones[i].Construct(preguntas.opciones[i], callback);
        }
    }

}
