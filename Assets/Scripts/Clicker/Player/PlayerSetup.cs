using System;
using System.Collections.Generic;
using System.Linq;
using Clicker.ResourceProduction;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.Player{
    public class PlayerSetup : MonoBehaviour{
        public PlayerData playerData;
        public Data starterTrainer;
        public PlayersActiveProducer activeProducer;
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
        public Image characterSpriteDisplay;
        public Text trainerPopUpIncomeText;
        public Text caloriesBurnedGymText;
        public Text userName;
        public BodyType savedBody;
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
        
        public int playerBodyType{
            get => PlayerPrefs.GetInt("ActiveBody", 0);
            set => PlayerPrefs.SetInt("ActiveBody", value);
        }
        void Start(){
            CheckForActivePlayer();
            savedBody = (BodyType) playerBodyType;
            SwitchBodyType(savedBody);
            userName.text = playerData.playerName;
            InitiateStartTrainer();
        }
        public void SwitchBodyType(BodyType bodyType){
            switch (bodyType){
                //here we set the values needed for amount of burned calories and amount of intake calories etc.
                case BodyType.Obese2:
                    characterSpriteDisplay.sprite = characterSprites[0];
                    bodyTypeText.text = "Body type: Class 2 obese";
                    playerData.caloriesNeededToBurn = 4200;
                    playerData.intakeCalories.Owned = 600;
                    weightText.text = "Weight: 150";
                    playerBodyType = (int) BodyType.Obese2;
                    break;
                case BodyType.Obese1:
                    characterSpriteDisplay.sprite = characterSprites[1];
                    bodyTypeText.text = "Body type: Class 1 obese";
                    playerData.caloriesNeededToBurn = 8400;
                    playerData.intakeCalories.Owned = 1200;
                    weightText.text = "Weight: 115";
                    playerBodyType = (int) BodyType.Obese1;
                    break;
                case BodyType.Average:
                    characterSpriteDisplay.sprite = characterSprites[2];
                    bodyTypeText.text = "Body type: Average";
                    playerData.caloriesNeededToBurn = 16800;
                    playerData.intakeCalories.Owned = 2400;
                    weightText.text = "Weight: 80";
                    playerBodyType = (int) BodyType.Average;
                    break;
                
                case BodyType.Athletic:
                    characterSpriteDisplay.sprite = characterSprites[3];
                    bodyTypeText.text = "Body type: Athletic";
                    playerData.caloriesNeededToBurn = 33600;
                    playerData.intakeCalories.Owned = 4800;
                    weightText.text = "Weight: 95";
                    playerBodyType = (int) BodyType.Athletic;
                    break;
                case BodyType.Muscular:
                    characterSpriteDisplay.sprite = characterSprites[4];
                    bodyTypeText.text = "Body type: Muscular";
                    playerData.caloriesNeededToBurn = 67200;
                    playerData.intakeCalories.Owned = 9600;
                    weightText.text = "Weight: 110";
                    playerBodyType = (int) BodyType.Muscular;
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
            }
        }

        public void UpdateBodyType(){
            savedBody = (BodyType) playerBodyType;
            SwitchBodyType(savedBody);
        }
        public void InitiateStartTrainer(){
            if (playerData.currentTrainer != null){
                activeProducer.SetUp();
                var go = GameObject.FindWithTag("ActiveTrainer");
                go.GetComponent<ResourceProducer>().amount.Amount = 1;
            }
        }

        private void Update(){
            caloriesBurnedGymText.text = $"Calories burned:{playerData.burnedCalories.Owned} ";
            trainerPopUpIncomeText.text = $"Savings: {playerData.money.Owned}";
            caloriesBurnedText.text = $"Todays burned calories: {playerData.burnedCalories.Owned}";
            caloriesIntakeText.text = $"Todays calories intake: {playerData.intakeCalories.Owned}";
            savingsText.text = $"Savings: {playerData.money.Owned}";
            incomeText.text = $"Income: {playerData.income.Owned}";
            needToBurnText.text = $"You need to burn {playerData.caloriesNeededToBurn + playerData.intakeCalories.Owned} calories in order to advance.";
            if (dayDisplayScript.days2 == 7){
                // one week has passed and do the necessary calculations here.
            }
        }

        public void DisplayActiveTrainer(){
            var go = GameObject.FindWithTag("ActiveTrainer");
            go.gameObject.GetComponent<ResourceProducer>().data = playerData.currentTrainer;
            go.gameObject.GetComponent<ResourceProducer>().gameObject.name = playerData.currentTrainer.name;
            go.gameObject.GetComponent<ResourceProducer>().UpdateActiveText();
            playerData.usedTrainers.Add(playerData.currentTrainer.name);
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
