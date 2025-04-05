using UnityEngine;

public class cnair : MonoBehaviour
{
    public bool canBuild = false;

    public Material lineMaterial;
    public float lineWidth = 0.1f;

    private LineRenderer lineRenderer;
    [SerializeField] Transform punct;
    [SerializeField] GameObject car;

    void Start()
    {
        InitializeLineRenderer(); // Initialize the LineRenderer
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canBuild)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f; // Ensure the Z-position is properly set for 2D space
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            if (worldPos.y > -3.38f)
            {
                AddPoint(worldPos); // Add point to the LineRenderer
            }
        }
    }

    void AddPoint(Vector3 point)
    {
        // If the LineRenderer already has points, add the new point
        int pointCount = lineRenderer.positionCount;
        lineRenderer.positionCount = pointCount + 1;
        lineRenderer.SetPosition(pointCount, point); // Set the new point at the end
    }

    public void InitializeLineRenderer()
    {
        // Only create the LineRenderer if it's not already initialized
        if (lineRenderer == null)
        {
            GameObject lineObj = new GameObject("DynamicLine");
            lineRenderer = lineObj.AddComponent<LineRenderer>();
            lineRenderer.material = lineMaterial;
            lineRenderer.widthMultiplier = lineWidth;
            lineRenderer.positionCount = 0; // No points initially
            lineRenderer.useWorldSpace = true;
        }
    }

    public void Toggle()
    {
        canBuild = !canBuild;
        car.GetComponent<FollowPoints>().points[1] = punct;
    }
}
