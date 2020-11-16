using Clicker.ResourceProduction;
using Resources;
using UnityEngine;

namespace Clicker.Player{
    [CreateAssetMenu(menuName = "Clicker/Player character data", fileName = "New character data")]
    public class PlayerData : ScriptableObject{
    
        public ResourceProducer currentTrainer;
        public Resource money;
        public Resource calories;
        public Resource weight;
        public string playerName;
        public int MoneyAmount {
            get => PlayerPrefs.GetInt(this.name+"_Money", 1);
            private set => PlayerPrefs.SetInt(this.name+"_Money", value);
        }
        public int CaloriesAmount {
            get => PlayerPrefs.GetInt(this.name+"_calories", 1);
            private set => PlayerPrefs.SetInt(this.name+"_calories", value);
        }
        public void GetAmount(int amount, Resource resource){
            resource.Owned = amount;
        }
        public void UpdateCurrentTrainer(){
            foreach (var productionUnit in FindObjectOfType<Setup>().datas){
                if (currentTrainer.id == productionUnit.id){
                    currentTrainer.data = productionUnit;
                }
                else return;
            }
        }
    }
}
