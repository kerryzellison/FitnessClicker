using System;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.Player{
    public class CaloriesProgression : MonoBehaviour{
        public PlayerData playerData;
        public int clickCounter = 0;
        public ProgressBar progressBar;
        public Sprite[] CharacterSprites;
        public Sprite[] characterSprite1;
        public Sprite[] characterSprite2;
        public Sprite[] characterSprite3;
        public Sprite[] characterSprite4;
        public Image renderer;

        private void Start(){
            progressBar.SetProgress(0);
            progressBar.SetMaxProgress(3);
            renderer.sprite = CharacterSprites[clickCounter];
        }

        private void Update(){
            UpdateCounterAndCalories();
        }

        void UpdateCounterAndCalories(){
            if (clickCounter >= 3){
                playerData.burnedCalories.Owned += 1000;
                clickCounter = 0;
            } 
        }
        public void Click()
        {
            clickCounter++;
            progressBar.SetProgress(clickCounter);
            renderer.sprite = CharacterSprites[clickCounter];
        }
    }
}
