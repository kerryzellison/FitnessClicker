using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSetup : MonoBehaviour{
    public PlayerData femaleData;
    public PlayerData maleData;
    public InputField inputField;
    public Button maleButton;
    public Button femaleButton;
    public Button submitButton;
    public GameObject startPopup;
    public bool male;
    public bool female;
    public bool activePlayer;
    public int playerIsActive{
        get => PlayerPrefs.GetInt("ActiveKey", 0);
        set => PlayerPrefs.SetInt("ActiveKey", value);
    }
    void Start(){
        // 0 equals no active player, 1 equals male active, 2 equals female active
        if (playerIsActive == 0) activePlayer = false;
        else if (playerIsActive == 1){
            activePlayer = true;
            male = true;}
        else if (playerIsActive == 2){ 
            activePlayer = true;
            female = true;
        }
        
        if (!activePlayer){
            startPopup.gameObject.SetActive(true);
            maleButton.gameObject.SetActive(false);
            femaleButton.gameObject.SetActive(false);
            inputField.gameObject.SetActive(true);
            submitButton.gameObject.SetActive(true); 
        }
        else if (activePlayer){
            startPopup.gameObject.SetActive(false);
            if (male){
                maleData.GetAmount(femaleData.CaloriesAmount, femaleData.calories);
                maleData.GetAmount(femaleData.MoneyAmount, femaleData.money);
                maleData.GetAmount(femaleData.WeightAmount, femaleData.weight);
                maleData.UpdateCurrentTrainer();
            }
            else if (female){
                femaleData.GetAmount(femaleData.CaloriesAmount, femaleData.calories);
                femaleData.GetAmount(femaleData.MoneyAmount, femaleData.money);
                femaleData.GetAmount(femaleData.WeightAmount, femaleData.weight); 
                femaleData.UpdateCurrentTrainer();
            }
        }
    }
    public void ClickMaleButton(){
        maleData.playerName = inputField.text;
        male = true;
        playerIsActive = 1;
        maleButton.gameObject.SetActive(false);
        femaleButton.gameObject.SetActive(false);
        startPopup.gameObject.SetActive(false);
    }
    public void ClickFemaleButton(){
        femaleData.playerName = inputField.text;
        female = true;
        playerIsActive = 2;
        maleButton.gameObject.SetActive(false);
        femaleButton.gameObject.SetActive(false);
        startPopup.gameObject.SetActive(false);
    }
    public void SubmitUserName(){
        maleButton.gameObject.SetActive(true);
        femaleButton.gameObject.SetActive(true);
        inputField.gameObject.SetActive(false);
        submitButton.gameObject.SetActive(false);
    }
    private void OnApplicationQuit(){
        if (male){
            maleData.SaveAmount(femaleData.CaloriesAmount, femaleData.calories);
            maleData.SaveAmount(femaleData.MoneyAmount, femaleData.money);
            maleData.SaveAmount(femaleData.WeightAmount, femaleData.weight);
        }
        else if (female){
            femaleData.SaveAmount(femaleData.CaloriesAmount, femaleData.calories);
            femaleData.SaveAmount(femaleData.MoneyAmount, femaleData.money);
            femaleData.SaveAmount(femaleData.WeightAmount, femaleData.weight); 
        }
    }
}
