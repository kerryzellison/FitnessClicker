using System;
using UnityEngine;

namespace Clicker.Player{
    public class CaloriesProgression : MonoBehaviour{
        public PlayerData playerData;
        public int clickCounter = 0;
        public ProgressBar progressBar;

        private void Start(){
            progressBar.SetProgress(0);
            progressBar.SetMaxProgress(3);
        }

        private void Update(){
            UpdateCounterAndCalories();
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
        }
    }
}
