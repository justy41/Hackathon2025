using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class SimulationManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float timer = 0f;
    private bool isRunning = false;
    [SerializeField] public TMP_Text timerText;
    
    List<GameObject> cars;
    void Start()
    {
        timerText.enabled = false;
        cars = GameObject.FindGameObjectsWithTag("obj").ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning) timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void startsim() {
        isRunning = true;
        timerText.enabled = true;
        
        for(int i = 0; i<cars.Count; i++) {
            cars[i].GetComponent<FollowPoints>().CAN_MOVE = true;
        }
    }
}
