using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject car;
    float spawnTimer;
    public float spawnTimerValue;
    public Transform[] points;
    
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
        if(spawnTimer <= 0) {
            Instantiate(car, transform.position, Quaternion.identity);
            spawnTimer = spawnTimerValue;
        }
    }
}
