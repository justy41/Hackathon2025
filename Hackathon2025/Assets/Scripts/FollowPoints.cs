using UnityEngine;

public class FollowPoints : MonoBehaviour
{
    public float speed;
    public Transform[] points;
    Transform currentPoint;
    int currentIndex = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPoint = points[currentIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.transform.position != points[points.Length - 1].position) {
            if(Vector2.Distance(transform.position, currentPoint.position) <= 0) {
                currentIndex++;
                currentPoint = points[currentIndex];
            }
            
            this.transform.position = Vector2.MoveTowards(transform.position, currentPoint.position, speed * Time.deltaTime);
        }
    }
}
