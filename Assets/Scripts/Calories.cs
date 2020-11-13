using UnityEngine;
using UnityEngine.UI;

public class Calories : MonoBehaviour
{
    public Text caloriesAmount;
    public static int calories;
    public int counter = 0;

    public void Start()
    {
        calories = 0;
    }

    public void Update() 
    {
        caloriesAmount.text = "Calories Burned: " + calories; // checks how many calories you have earned 

        if (counter >= 3)
        {
            calories += 3; // if the player clicks 3 times they get 1 calorie added and resets the counter to 0
            counter -= 3;
        }  
        
    }

    public void Click()
    {
        counter++;   // adds 1 to the counter so the scripts know how much the player has pressed
    }
}
