using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject car;
    float spawnTimer;
    public float spawnTimerValue;
    public List<Transform> points = new List<Transform>();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = spawnTimerValue;
        car.GetComponent<FollowPoints>().points = points;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0 && car.GetComponent<FollowPoints>().CAN_MOVE)
        {
            GameObject spawnedCar = Instantiate(car, transform.position, Quaternion.identity);
            spawnedCar.GetComponent<FollowPoints>().points = new List<Transform>(points); // Make a copy if needed
            spawnTimer = spawnTimerValue;
        }
    }
}
