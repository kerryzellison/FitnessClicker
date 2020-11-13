using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaloriesBurnedText : MonoBehaviour
{
 public Text caloriesBurned;
 public int caloriesMain;

 public void Update()
 {
  Calories.calories = caloriesMain;
  caloriesBurned.text = "Todays Calories Burned: " + caloriesMain ;
 }
}
