using System;
using UnityEngine;

public class FollowPoints : MonoBehaviour
{
    public float speed;
    public Transform[] points;
    Transform currentPoint;
    int currentIndex = 0;
    
    bool isTouchingCar;
    
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
            
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan((currentPoint.position.y-transform.position.y)/(currentPoint.position.x-transform.position.x)) * Mathf.Rad2Deg);
            
            if(!isTouchingCar) {
                this.transform.position = Vector2.MoveTowards(transform.position, currentPoint.position, speed * Time.deltaTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("fkhjkfj");
        if(other.CompareTag("car")) {
            isTouchingCar = true;
            Debug.Log("am atins masina");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("car")) {
            isTouchingCar = false;
        }
    }
}
