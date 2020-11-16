using Clicker.ResourceProduction;
using Resources;
using UnityEngine;
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
    public int WeightAmount {
        get => PlayerPrefs.GetInt(this.name+"_weight", 1);
        private set => PlayerPrefs.SetInt(this.name+"_weight", value);
    }
    public void SaveAmount(int amount, Resource resource){
        amount = resource.Owned;
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
