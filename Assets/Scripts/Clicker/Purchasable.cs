using System;
using Clicker.Player;
using Clicker.ResourceProduction;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker{
    [Serializable]
    public class Purchasable
    {
        public Setup trainerSetup;
        ResourceProduction.Data data;
        public Text buttonLabel;
        public Text ActiveLabel;
        string productId;
        public PlayerData playerData;
        private ResourceProducer _resourceProducer;

        bool IsAffordable => this.data.GetActualCosts().IsAffordable;

        public int Amount {
            get => PlayerPrefs.GetInt(this.data.name+"_"+this.productId, 0);
            set => PlayerPrefs.SetInt(this.data.name+"_"+this.productId, value);
        }

        public void SetUp(ResourceProduction.Data data, string productId,Setup trainerSetup, ResourceProducer resourceProducer){
            this.trainerSetup = trainerSetup;
            this.data = data;
            this.productId = productId;
            _resourceProducer = resourceProducer;
            UpdateText();
        }
        public void SetUpPlayer(ResourceProduction.Data data, string productId){
            this.data = data;
            this.productId = productId;
            UpdateTextForCurrent();
        }
        public void Purchase() {
            if (!this.IsAffordable) 
                return;
            this.data.GetActualCosts().Consume();
            this.Amount += 1;
            foreach (var productionUnit in trainerSetup.datas){
                if (productionUnit.name == this.data.name){
                    playerData.usedTrainers.Add(productionUnit.name);
                    playerData.currentTrainer = productionUnit;
                    trainerSetup.datas.Remove(productionUnit);
                    _resourceProducer.DestroyThisResourceProducer();
                    break;
                }
            }
        }
        public void UpdateTextForCurrent(){
            this.ActiveLabel.text = $"<color=#ffffff><size=50>{this.data.name}:</size></color> \n" +
                                    $"<color=#000000><size=30>Burns {this.data.GetProductionAmount()} calorie per {this.data.productionTime / 60} minutes.</size></color>";
        }
        public void Update() => UpdateText();
        void UpdateText() => this.buttonLabel.text = this.IsAffordable ? $"<color=#ffffff><size=40>Costs: {this.data.GetActualCosts()}</size></color>" : 
            $"<color=#ff0000><size=40>Costs: {this.data.GetActualCosts()}</size></color>";
    }
}
