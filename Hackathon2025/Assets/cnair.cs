using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Transactions;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.U2D;

public class cnair : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    
    [SerializeField] LineRenderer lineRenderer;
    private UnityEngine.Vector2 mp;
    private bool start = false;
    void Start()
    {
        lineRenderer.useWorldSpace = true;
    }

    public List<UnityEngine.Vector3> pozitii = new List<UnityEngine.Vector3>();
    int cnt = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            if(start == false) {
                start = true;
                mp = Input.mousePosition;
                UnityEngine.Vector3 sp = Camera.main.ScreenToWorldPoint(mp);
                sp.z = 0f;
                pozitii.Add(sp);
            } else {
                mp = Input.mousePosition;
                UnityEngine.Vector3 sp = Camera.main.ScreenToWorldPoint(mp);
                sp.z = 0f;
                pozitii.Add(sp);
                
            }
        }
    }
}
