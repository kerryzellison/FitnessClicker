using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavingsText : MonoBehaviour
{
    public Text savingsText;
    public double savings;

    public void Start()
    {
        savings = 0;
    }

    public void Update()
    {
        savingsText.text = "Savings: " + savings;
    }

   public void Click() // when end day is pressed player will get X amount of money
    {
        savings += 1000;
    }
}