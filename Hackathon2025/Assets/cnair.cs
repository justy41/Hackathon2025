using System.Collections.Generic;
using UnityEngine;

public class cnair : MonoBehaviour
{
    public bool canBuild = false;

    public Material lineMaterial;
    public float lineWidth = 0.1f;

    private LineRenderer lineRenderer;
    private List<Vector3> points = new List<Vector3>();

    [SerializeField] GameObject car;
    FollowPoints fp;

    void Start()
    {
        fp = car.GetComponent<FollowPoints>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canBuild)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            if (worldPos.y > -3.38f)
            {
                AddPoint(worldPos);

                // Create a new empty GameObject for the follow point
                GameObject pointObj = new GameObject("FollowPoint");
                pointObj.transform.position = new Vector3(worldPos.x, worldPos.y, 0f);

                // Add to car's follow points list (append)
                fp.points.Add(pointObj.transform);
            }
        }
    }

    void AddPoint(Vector3 point)
    {
        points.Add(point);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);
    }

    public void NewRoadPoints()
    {
        points.Clear();

        GameObject lineObj = new GameObject("DynamicLine");
        lineRenderer = lineObj.AddComponent<LineRenderer>();
        lineRenderer.material = lineMaterial;
        lineRenderer.widthMultiplier = lineWidth;
        lineRenderer.positionCount = 0;
        lineRenderer.useWorldSpace = true;

    }

    public void Toggle()
    {
        canBuild = !canBuild;
    }
}
