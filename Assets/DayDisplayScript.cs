using System;
using System.Collections;
using System.Collections.Generic;
using Clicker.Player;
using UnityEngine;
using UnityEngine.UI;

public class DayDisplayScript : MonoBehaviour{
    public DaySystemScript timerScript;
    public long startTime;
    public Text timeText;
    public Text numberOfDays;
    public long milliseconds;
    public int seconds;
    public int days = 1;
    private TimeSpan timeSpan;

    public void Start(){
        startTime = timerScript.GetEpochTimeMilliseconds();
        numberOfDays.text = $"You have been a member for: {days} days";
    }
    public void Update(){
        milliseconds = timerScript.GetEpochTimeMilliseconds() - startTime;
        seconds = (int) TimeSpan.FromMilliseconds(milliseconds).TotalSeconds;
        timeSpan = TimeSpan.FromSeconds(seconds * 48); // times 48 for 30 min real time
        if (timeSpan.Days == 1){
            resetTimer();
        }
        timeText.text = $"Time - {timeSpan}";
    }
    void resetTimer(){
        startTime = timerScript.GetEpochTimeMilliseconds();
        days++;
        numberOfDays.text = $"You have been a member for: {days} days";
    }

    public void ResetDay(){
        resetTimer();
    }
}
