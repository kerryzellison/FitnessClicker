using System;
using System.Collections;
using System.Collections.Generic;
using Clicker.Player;
using UnityEngine;
using UnityEngine.UI;

public class DayDisplayScript : MonoBehaviour{
    public DaySystemScript timerScript;
    public PlayerSetup playerSetup;
    public PlayerData playerData;
    public Button endDayButton;
    public long startTime;
    public Text timeText;
    public Text numberOfDays;
    public Text weekDaysText;
    public long milliseconds;
    public int seconds;
    [SerializeField]
    private TimeSpan timeSpan;
    public int days2 = 0;

    public int Days{
        get => PlayerPrefs.GetInt("Days", 1);
        set => PlayerPrefs.SetInt("Days", value);
    }

    public void Start(){
        startTime = timerScript.GetEpochTimeMilliseconds();
        numberOfDays.text = $"You have been a member for: {Days} days";
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
        timeText.text = $"Time of day: {timeSpan}";
        if (playerData.burnedCalories.Owned < playerData.dailyCalsNeedToBurn){
            var colorBlock = endDayButton.colors;
            colorBlock.normalColor = Color.red;
            colorBlock.highlightedColor = Color.gray;
            colorBlock.pressedColor = Color.gray;
            endDayButton.colors = colorBlock;
        }
        else{
            var colorBlock = endDayButton.colors;
            colorBlock.normalColor = Color.green;
            colorBlock.highlightedColor = Color.green;
            colorBlock.pressedColor = Color.green;
            endDayButton.colors = colorBlock;
        }
    }
    void resetTimer(){
        startTime = timerScript.GetEpochTimeMilliseconds();
        Days += 1;
        days2++;
        UpdateIncome();
        UpdateCalories();
        if (days2 >= 7){
            if (playerData.calories.Owned >= playerData.caloriesNeededToBurn){
                if (playerSetup.playerBodyType == 0){
                    playerSetup.playerBodyType = 1;
                }
                else if (playerSetup.playerBodyType == 1){
                    playerSetup.playerBodyType = 2;
                }
                else if (playerSetup.playerBodyType == 2){
                    playerSetup.playerBodyType = 3;
                }
                else if (playerSetup.playerBodyType == 3){
                    playerSetup.playerBodyType = 4;
                }
                else if (playerSetup.playerBodyType == 4){
                    playerSetup.playerBodyType = 4;
                }
                playerData.calories.Owned = 0;
            }else if (playerData.calories.Owned < playerData.caloriesNeededToBurn){
                if (playerSetup.playerBodyType == 0){
                    playerSetup.playerBodyType = 0;
                }
                else if (playerSetup.playerBodyType == 1){
                    playerSetup.playerBodyType = 0;
                }
                else if (playerSetup.playerBodyType == 2){
                    playerSetup.playerBodyType = 1;
                }
                else if (playerSetup.playerBodyType == 3){
                    playerSetup.playerBodyType = 2;
                }
                else if (playerSetup.playerBodyType == 4){
                    playerSetup.playerBodyType = 3;
                }
                playerData.calories.Owned = 0;
            }
            playerSetup.UpdateBodyType();
            days2 = 0;
        }
        SetCurrentDay();
        numberOfDays.text = $"You have been a member for: {Days} days";
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
        if (playerData.burnedCalories.Owned < playerData.dailyCalsNeedToBurn){
            var colorBlock = endDayButton.colors;
            colorBlock.normalColor = Color.red;
            colorBlock.highlightedColor = Color.gray;
            colorBlock.pressedColor = Color.gray;
            endDayButton.colors = colorBlock;
            return;
        }
        resetTimer();
    }
    public void UpdateIncome(){
        playerData.money.Owned += 1000;
    }
    void UpdateCalories(){
        playerData.calories.Owned += playerData.burnedCalories.Owned;
        playerData.caloriesNeededToBurn -= playerData.burnedCalories.Owned;
        if (playerData.caloriesNeededToBurn <= 0){
            playerData.caloriesNeededToBurn = 0;
        }
        playerData.burnedCalories.Owned = 0;
    }
}
