using UnityEngine;

namespace Clicker.Player{
    public class CaloriesProgression : MonoBehaviour{
        public PlayerData playerData;
        public int clickCounter = 0;
        
        private void Update(){
            UpdateCounterAndCalories();
        }

        void UpdateCounterAndCalories(){
            if (clickCounter >= 3){
                playerData.burnedCalories.Owned += 3;
                clickCounter = 0;
            } 
        }
        public void Click()
        {
            clickCounter++;   // adds 1 to the counter so the scripts know how much the player has pressed
        }
    }
}
