using UnityEngine;
using UnityEngine.UI;

public class Calories : MonoBehaviour
{
    public Text caloriesAmount;
    public double calories;
    public int counter = 0;

    public void Start()
    {
        calories = 0;
    }

    public void Update() 
    {
        caloriesAmount.text = "calories: " + calories; // checks how many calories you have earned 

        if (counter >= 2)
        {
            calories += 1; // if the player clicks 2 times they get 1 calorie added and resets the counter to 0
            counter -= 2;
        }  
        
    }

    public void Click()
    {
        counter++;   // adds 1 to the counter so the scripts know how much the player has pressed
    }
}
