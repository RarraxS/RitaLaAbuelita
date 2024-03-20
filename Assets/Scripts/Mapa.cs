using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    [SerializeField] private GameObject mapa_;
    // Start is called before the first frame update
    void Start()
    {
        mapa_.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        if (Input.GetKey(KeyCode.M))
        {
            mapa_.SetActive(true);
        }
    }
}
