using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDay : MonoBehaviour
{
    public static bool endDayButton = false;
    public int calorieGoal = Calories.calories;

    private void Start()
    {
        
      
    }
    public void Update()
    {
        Click();
    }

    public void Click()
    {
        if (calorieGoal >= 10)
        {
            endDayButton = true;
            Debug.Log("its working");
        }

        calorieGoal = 0;
    }
}

