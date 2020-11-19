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
        [SerializeField]
        public int caloriesNeededToBurn;
        [SerializeField]
        public int dailyCalsNeedToBurn;
        private string PlayerName;
        public string playerName{
            get => PlayerPrefs.GetString("PlayerName", PlayerName);
            set => PlayerPrefs.SetString("PlayerName", value);
        }
        [SerializeField]
        public List<string> usedTrainers;
    }
}
