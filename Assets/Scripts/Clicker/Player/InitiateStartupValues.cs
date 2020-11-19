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
        public Text currentBurnedCalories;
        public Text usernameText;
        public Text intakeCaloriesText;
        public Text IncomeText;

        public void SetStartupValues(){
            playerData.usedTrainers.Clear();
            playerData.usedTrainers.Add(playerSetup.starterTrainer.name);
            playerData.currentTrainer = playerSetup.starterTrainer;
            playerData.calories.Owned = caloriesStartAmount;
            playerData.burnedCalories.Owned = burnedCaloriesStartAmount;
            playerData.money.Owned = startingMoneyAmount;
            //playerData.intakeCalories.Owned = startingIntakeCalories;
            dayDisplayScript.startTime = dayDisplayScript.timerScript.GetEpochTimeMilliseconds();
            moneyText.text = $"Money: {startingMoneyAmount}";
            currentBurnedCalories.text = $"Todays calories burned: {burnedCaloriesStartAmount}";
            usernameText.text = playerData.playerName;
            intakeCaloriesText.text = $"Todays calories intake: {intakeCaloriesText}";
            playerSetup.SwitchBodyType(PlayerSetup.BodyType.Obese2);
            playerData.income.Owned = 1000;
            IncomeText.text = $"Income; {playerData.income.Owned}";
            playerSetup.InitiateStartTrainer();
        }
    }
}
