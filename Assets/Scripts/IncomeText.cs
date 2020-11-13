using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IncomeText : MonoBehaviour
{
    public Text incomeText;
    public double income;

    public void Start()
    {
        income = 0;
    }

    public void Update()
    {
        incomeText.text = "Income: " + income;

       if (GetComponent<EndDay>()) // when end day is pressed player will get X amount of money 
        {
            income += 1000;
        }
    }
}
