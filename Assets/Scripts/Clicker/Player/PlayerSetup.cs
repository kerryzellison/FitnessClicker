using System;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.Player{
    public class PlayerSetup : MonoBehaviour{
        public PlayerData playerData;
        public InputField inputField;
        public Button submitButton;
        public Button startButton;
        public GameObject startPopup;
        public GameObject welcomeScreen;
        public bool activePlayer;
        public int playerIsActive{
            get => PlayerPrefs.GetInt("ActiveKey", 0);
            set => PlayerPrefs.SetInt("ActiveKey", value);
        }
        void Start(){
            // 0 equals no active player, 1 player is active
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
