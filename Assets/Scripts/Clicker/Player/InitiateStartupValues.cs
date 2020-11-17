using UnityEngine;
using UnityEngine.UI;

namespace Clicker.Player{
    public class InitiateStartupValues : MonoBehaviour{
        public PlayerData playerData;
        public DayDisplayScript dayDisplayScript;
        public PlayerSetup playerSetup;
        public int caloriesStartAmount;
        public int burnedCaloriesStartAmount;
        public int startingMoneyAmount;
        public int startingIntakeCalories;
        public Text moneyText;
        public Text bodyTypeText;
        public Text currentBurnedCalories;
        public Text usernameText;
        public Text intakeCaloriesText;

        public void SetStartupValues(){
            playerData.calories.Owned = caloriesStartAmount;
            playerData.burnedCalories.Owned = burnedCaloriesStartAmount;
            playerData.money.Owned = startingMoneyAmount;
            playerData.intakeCalories.Owned = startingIntakeCalories;
            dayDisplayScript.days = 1;
            dayDisplayScript.startTime = dayDisplayScript.timerScript.GetEpochTimeMilliseconds();
            moneyText.text = $"Money: {startingMoneyAmount}";
            //bodyTypeText.text = $"Body type: Undecided";
            currentBurnedCalories.text = $"Todays calories burned: {burnedCaloriesStartAmount}";
            usernameText.text = playerData.playerName;
            intakeCaloriesText.text = $"Todays calories intake: {intakeCaloriesText}";
            playerSetup.SwitchBodyType(PlayerSetup.BodyType.Obese2);
        }
    }
}
