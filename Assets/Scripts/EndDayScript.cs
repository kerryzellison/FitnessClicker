using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndDayScript : MonoBehaviour
{
    public Text savingsText;
    public double savings;
    public Text workedOutForText;
    public int workedOutDaysAmount;
    public Calories calories;
    public CaloriesBurned kcalsBurnedText;
    public WeeklyCalories WeeklyCalories;
    public void Start()
    {
        savings = 0;
    }

    public void Update()
    {
        savingsText.text = "Savings: " + savings;
        workedOutForText.text = "You've been a member for: " + workedOutDaysAmount + " Days";
    }

    public void Click() // when end day is pressed player will get X amount of money
    {
        
        savings += 1000;
        workedOutDaysAmount++;
        WeeklyCalories.SavedWeeklyCalories += calories.calories;
        calories.calories = 0;
        kcalsBurnedText.caloriesBurned.text = calories.calories.ToString();
        WeeklyCalories.DayCounter++;
        
    }

}