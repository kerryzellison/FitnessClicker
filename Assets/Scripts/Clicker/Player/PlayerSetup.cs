using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.Player{
    public class PlayerSetup : MonoBehaviour{
        public PlayerData playerData;
        public DayDisplayScript dayDisplayScript;
        public InputField inputField;
        public Button submitButton;
        public Button startButton;
        public GameObject startPopup;
        public GameObject welcomeScreen;
        public Text caloriesBurnedText;
        public Text caloriesIntakeText;
        public Text savingsText;
        public Text incomeText;
        public Text bodyTypeText;
        public Text needToBurnText;
        public Text weightText;
        public Sprite[] characterSprites;
        public GameObject characterSpriteDisplay;
        public enum BodyType{
            Obese2,
            Obese1,
            Average,
            Athletic,
            Muscular
        }
        
        public bool activePlayer;
        public int playerIsActive{
            get => PlayerPrefs.GetInt("ActiveKey", 0);
            set => PlayerPrefs.SetInt("ActiveKey", value);
        }
        void Start(){
            CheckForActivePlayer();
        }

        public void SwitchBodyType(BodyType bodyType){
            switch (bodyType){
                //here we set the values needed for amount of burned calories and amount of intake calories etc.
                case BodyType.Obese2:
                    //characterSpriteDisplay.GetComponent<SpriteRenderer>().sprite = characterSprites[0];
                    bodyTypeText.text = "Body type: Class 2 obese";
                    playerData.caloriesNeededToBurn = 600;
                    playerData.intakeCalories.Owned = 600;
                    weightText.text = "Weight: 150";
                    break;
                case BodyType.Obese1:
                    characterSpriteDisplay.GetComponent<SpriteRenderer>().sprite = characterSprites[1];
                    bodyTypeText.text = "Body type: Class 1 obese";
                    playerData.caloriesNeededToBurn = 1200;
                    playerData.intakeCalories.Owned = 1200;
                    weightText.text = "Weight: 115";
                    break;
                case BodyType.Average:
                    characterSpriteDisplay.GetComponent<SpriteRenderer>().sprite = characterSprites[2];
                    bodyTypeText.text = "Body type: Average";
                    playerData.caloriesNeededToBurn = 2400;
                    playerData.intakeCalories.Owned = 2400;
                    weightText.text = "Weight: 80";
                    break;
                case BodyType.Athletic:
                    characterSpriteDisplay.GetComponent<SpriteRenderer>().sprite = characterSprites[3];
                    bodyTypeText.text = "Body type: Athletic";
                    playerData.caloriesNeededToBurn = 4800;
                    playerData.intakeCalories.Owned = 4800;
                    weightText.text = "Weight: 95";
                    break;
                case BodyType.Muscular:
                    characterSpriteDisplay.GetComponent<SpriteRenderer>().sprite = characterSprites[4];
                    bodyTypeText.text = "Body type: Muscular";
                    playerData.caloriesNeededToBurn = 9600;
                    playerData.intakeCalories.Owned = 9600;
                    weightText.text = "Weight: 110";
                    break;
            }
        }

        private void CheckForActivePlayer(){
            // 0 equals no active player, 1 equals player is active
            if (playerIsActive == 0) activePlayer = false;
            else if (playerIsActive == 1) activePlayer = true;

            if (!activePlayer){
                welcomeScreen.SetActive(true);
                startPopup.gameObject.SetActive(true);
                inputField.gameObject.SetActive(true);
                submitButton.gameObject.SetActive(true);
            }
            else if (activePlayer){
                welcomeScreen.SetActive(true);
                startPopup.SetActive(true);
                inputField.gameObject.SetActive(false);
                submitButton.gameObject.SetActive(false);
                playerData.GetAmount(playerData.CaloriesAmount, playerData.calories);
                playerData.GetAmount(playerData.MoneyAmount, playerData.money);
                //playerData.UpdateCurrentTrainer();
            }
        }

        private void Update(){
            caloriesBurnedText.text = $"Todays burned calories: {playerData.burnedCalories.Owned}";
            caloriesIntakeText.text = $"Todays calories intake: {playerData.intakeCalories.Owned}";
            savingsText.text = $"Savings: {playerData.money.Owned}";
            incomeText.text = $"Income: {playerData.income.Owned}";
            needToBurnText.text =
                $"You need to burn {playerData.caloriesNeededToBurn} calories in order to advance.";
            if (dayDisplayScript.days2 == 7){
                // one week has passed and do the necessary calculations here.
            }
        }

        void CalculateTodaysIncome(){
            //Use this when ending day for amount of money gained.
        }

        void CalculateCurrentCalories(){
            //Use this for calculating the users total current calories
        }

        void CalculateBodyType(){
            //use this for calculating the body typ of the user depending on users total amount of calories.
            //Here you set the _bodyType and call the method SwitchBodyType.
            /*
             if (playerData.calories.Owned >= 9000){
                _bodyType = BodyType.Obese2;
            }
            */
        }
        public void ClickStartButton(){
            welcomeScreen.SetActive(false);
            if(activePlayer) startPopup.SetActive(false);
        }
        public void SubmitUserName(){
            playerIsActive = 1;
            playerData.playerName = inputField.text;
            startPopup.SetActive(false);
        }
    }
}
