using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDay : MonoBehaviour
{
    public int calorieGoal;
    public bool endDayButton = false;


 private void Start()
 {
     calorieGoal = Calories.calories;
 }

 public void Update()
    {
        if ((calorieGoal = 50)
        {
            endDayButton = true;
            Click();
        }
    }

 public void Click()
    {
        calorieGoal = 0;
    }
}

