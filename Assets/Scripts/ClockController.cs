using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockController : MonoBehaviour
{
    private float elapsedTime;
    private float timeInADay = 86400f;
    public int dayCount = 1;
    [SerializeField] private TMP_Text day;
    [SerializeField] private TMP_Text time;
    [SerializeField] private float timeScale = 60.0f;

    private void Update()
    {
        float previousTime = elapsedTime;
        elapsedTime += Time.deltaTime * timeScale;
        
        if (previousTime < timeInADay && elapsedTime >= timeInADay)
        {
            dayCount += 1;
        }
        
        elapsedTime %= timeInADay;
        UpdateClockUI();
        UpdateDay();
    }

    void UpdateClockUI()
    {
        int hours = Mathf.FloorToInt(elapsedTime / 3600f);
        int minutes = Mathf.FloorToInt((elapsedTime - hours * 3600f) / 60f);
        int seconds = Mathf.FloorToInt((elapsedTime - hours * 3600f) - (minutes * 60f));

        string clockString = string.Format("{0:00}:{1:00}", hours, minutes);
        time.text = clockString;
    }

    void UpdateDay()
    {
        day.text = dayCount.ToString();
    }
}