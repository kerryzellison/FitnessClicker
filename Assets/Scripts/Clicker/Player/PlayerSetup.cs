using UnityEngine;
using UnityEngine.UI;

namespace Clicker.Player{
    public class PlayerSetup : MonoBehaviour{
        public PlayerData playerData;
        public InputField inputField;
        public Button submitButton;
        public GameObject startPopup;
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
                startPopup.gameObject.SetActive(true);
                inputField.gameObject.SetActive(true);
                submitButton.gameObject.SetActive(true); 
            }
            else if (activePlayer){
                startPopup.gameObject.SetActive(false);
                playerData.GetAmount(playerData.CaloriesAmount, playerData.calories);
                playerData.GetAmount(playerData.MoneyAmount, playerData.money);
                //playerData.UpdateCurrentTrainer();
            }
        }
        public void SubmitUserName(){
            playerIsActive = 1;
            playerData.playerName = inputField.text;
            startPopup.gameObject.SetActive(false);
        }
    }
}
