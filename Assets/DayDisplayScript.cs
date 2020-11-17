using System;
using System.Collections;
using System.Collections.Generic;
using Clicker.Player;
using UnityEngine;
using UnityEngine.UI;

public class DayDisplayScript : MonoBehaviour{
    public DaySystemScript timerScript;
    public PlayerData playerData;
    public CaloriesProgression caloriesProgression;
    public long startTime;
    public Text timeText;
    public Text numberOfDays;
    public long milliseconds;
    public int seconds;
    public int days = 1;
    private TimeSpan timeSpan;
    public int days2 = 1;

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
        days2++;
        UpdateIncome();
        UpdateCalories();
        if (days2 >= 7){
            days2 = 0;
        }
        numberOfDays.text = $"You have been a member for: {days} days";
    }

    public void ResetDay(){
        resetTimer();
    }
    public void UpdateIncome(){
        playerData.income.Owned += 1000;
    }
    void UpdateCalories(){
        if (playerData.burnedCalories.Owned >= playerData.intakeCalories.Owned){
            var burnedCalories = playerData.burnedCalories.Owned - playerData.intakeCalories.Owned;
            playerData.calories.Owned -= burnedCalories;
            playerData.caloriesNeededToBurn -= burnedCalories;
            playerData.burnedCalories.Owned = 0;
        }else if (playerData.burnedCalories.Owned <= playerData.intakeCalories.Owned){
            var burnedCalories = playerData.burnedCalories.Owned - playerData.intakeCalories.Owned;
            playerData.calories.Owned += burnedCalories;
            playerData.caloriesNeededToBurn += burnedCalories;
            playerData.burnedCalories.Owned = 0;
        }
    }
}
