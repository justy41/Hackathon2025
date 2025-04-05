using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class cnair : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    
    Transform transform;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)) {
            if(transform == null) Debug.Log("caca");
        }
    }

}
