using System;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.Player{
    public class CaloriesProgression : MonoBehaviour{
        public PlayerData playerData;
        public PlayerSetup playerSetup;
        public int clickCounter = 0;
        public ProgressBar progressBar;
        public Sprite[] characterSprites;
        public Sprite[] characterSprites1;
        public Sprite[] characterSprites2;
        public Sprite[] characterSprites3;
        public Sprite[] characterSprites4;
        public Image renderer;

        private void Start(){
            progressBar.SetProgress(0);
            progressBar.SetMaxProgress(3);
            clickCounter = 0;
            OnclickUpdate();
        }

        private void Update(){
            UpdateCounterAndCalories();
            OnclickUpdate();
        }

        void UpdateCounterAndCalories(){
            if (clickCounter >= 3){
                playerData.burnedCalories.Owned += 300;
                clickCounter = 0;
            } 
        }
        public void Click()
        {
            clickCounter++;
            progressBar.SetProgress(clickCounter);
            OnclickUpdate();
        }

        public void OnclickUpdate(){
            if (playerSetup.playerBodyType == 0){
                renderer.sprite = characterSprites[clickCounter];
            }
            else if (playerSetup.playerBodyType == 1){
                renderer.sprite = characterSprites1[clickCounter];
            }
            else if (playerSetup.playerBodyType == 2){
                renderer.sprite = characterSprites2[clickCounter];
            }
            else if (playerSetup.playerBodyType == 3){
                renderer.sprite = characterSprites3[clickCounter];
            }
            else if (playerSetup.playerBodyType == 4){
                renderer.sprite = characterSprites4[clickCounter];
            }
        }
    }
}
