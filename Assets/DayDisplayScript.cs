using System;
using System.Collections;
using System.Collections.Generic;
using Clicker.Player;
using UnityEngine;
using UnityEngine.UI;

public class DayDisplayScript : MonoBehaviour{
    public DaySystemScript timerScript;
    public PlayerData playerData;
    public Button endDayButton;
    public long startTime;
    public Text timeText;
    public Text numberOfDays;
    public Text weekDaysText;
    public long milliseconds;
    public int seconds;
    public int days = 1;
    private TimeSpan timeSpan;
    public int days2 = 0;

    public void Start(){
        startTime = timerScript.GetEpochTimeMilliseconds();
        numberOfDays.text = $"You have been a member for: {days} days";
        days2 = 0;
        SetCurrentDay();
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
        SetCurrentDay();
        numberOfDays.text = $"You have been a member for: {days} days";
    }

    void SetCurrentDay(){
        if (days2 == 0){
            weekDaysText.text = "Current day of the week: Monday";
        }else if (days2 == 1){
            weekDaysText.text = "Current day of the week: Tuesday";
        }else if (days2 == 2){
            weekDaysText.text = "Current day of the week: Wednesday";
        }else if (days2 == 3){
            weekDaysText.text = "Current day of the week: Thursday";
        }else if (days2 == 4){
            weekDaysText.text = "Current day of the week: Friday";
        }else if (days2 == 5){
            weekDaysText.text = "Current day of the week: Saturday";
        }else if (days2 == 6){
            weekDaysText.text = "Current day of the week: Sunday";
        }
    }
    public void ResetDay(){
        if (playerData.burnedCalories.Owned < playerData.intakeCalories.Owned){
            var colorBlock = endDayButton.colors;
            colorBlock.pressedColor = Color.gray;
            endDayButton.colors = colorBlock;
            return;
        }
        var colorBlock2 = endDayButton.colors;
        colorBlock2.pressedColor = Color.green;
        endDayButton.colors = colorBlock2;
        resetTimer();
    }
    public void UpdateIncome(){
        playerData.money.Owned += 1000;
    }
    void UpdateCalories(){
        if (playerData.burnedCalories.Owned >= playerData.intakeCalories.Owned){
            var burnedCalories = playerData.burnedCalories.Owned - playerData.intakeCalories.Owned;
            playerData.calories.Owned -= burnedCalories;
            playerData.caloriesNeededToBurn -= burnedCalories;
            playerData.burnedCalories.Owned = 0;
        }else if (playerData.burnedCalories.Owned <= playerData.intakeCalories.Owned){
            var burnedCalories = playerData.intakeCalories.Owned - playerData.burnedCalories.Owned;
            playerData.calories.Owned += burnedCalories;
            playerData.caloriesNeededToBurn += burnedCalories;
            playerData.burnedCalories.Owned = 0;
        }
    }
}
