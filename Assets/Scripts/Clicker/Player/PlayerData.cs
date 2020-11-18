using Clicker.ResourceProduction;
using Resources;
using UnityEngine;

namespace Clicker.Player{
    [CreateAssetMenu(menuName = "Clicker/Player character data", fileName = "New character data")]
    public class PlayerData : ScriptableObject{
    
        public Data currentTrainer;
        public Resource money;
        public Resource calories;
        public Resource burnedCalories;
        public Resource intakeCalories;
        public Resource income;
        public int caloriesNeededToBurn;
        public string playerName;
        
        public void UpdateCurrentTrainer(){
            foreach (var productionUnit in FindObjectOfType<Setup>().datas){
                if (currentTrainer.id == productionUnit.id){
                    currentTrainer = productionUnit;
                }
                else return;
            }
        }
    }
}
