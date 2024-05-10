using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Termometro : MonoBehaviour
{
    public GameObject Cuchillo;

    public Transform startPoint;
    public Transform endPoint;

    public float velocidad;

    public Vector3 moverHacia;

    void Start()
    {
        moverHacia = endPoint.position;
    }

    void Update()
    {
        Cuchillo.transform.position = Vector3.MoveTowards(Cuchillo.transform.position, moverHacia, velocidad *Time.deltaTime);

        if (Cuchillo.transform.position == endPoint.position) 
        {
            moverHacia = startPoint.position;
        }

        if (Cuchillo.transform.position == startPoint.position)
        {
            moverHacia = endPoint.position;
        }
    }
}
