using System.Collections.Generic;
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
        public int dailyCalsNeedToBurn;
        public string playerName;
        public List<string> usedTrainers;
    }
}
