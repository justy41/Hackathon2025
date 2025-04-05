using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimulationManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float timer = 0f;
    private bool isRunning = false;
    [SerializeField] public TMP_Text timerText;
    void Start()
    {
        timerText.enabled = false;
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
    }
}
