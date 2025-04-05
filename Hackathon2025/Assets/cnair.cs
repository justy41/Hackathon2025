using System.Collections.Generic;
using UnityEngine;

public class cnair : MonoBehaviour
{
    public Material lineMaterial;
    public float lineWidth = 0.1f;

    private LineRenderer lineRenderer;
    private List<Vector3> points = new List<Vector3>();

    void Start()
    {
        // Create a new GameObject and add LineRenderer at runtime
        GameObject lineObj = new GameObject("DynamicLine");
        lineRenderer = lineObj.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.widthMultiplier = lineWidth;
        lineRenderer.positionCount = 0;
        lineRenderer.useWorldSpace = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f; // Distance from camera
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            AddPoint(worldPos);
        }
    }

    void AddPoint(Vector3 point)
    {
        points.Add(point);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);
    }
}
