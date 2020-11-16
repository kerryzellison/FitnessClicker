using System;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker{
    [Serializable]
    public class Purchasable
    {
        ResourceProduction.Data data;
        public Text buttonLabel;
        string productId;
        public PlayerData playerData;

        bool IsAffordable => this.data.GetActualCosts().IsAffordable;

        public int Amount {
            get => PlayerPrefs.GetInt(this.data.name+"_"+this.productId, 0);
            private set => PlayerPrefs.SetInt(this.data.name+"_"+this.productId, value);
        }

        public void SetUp(ResourceProduction.Data data, string productId) {
            this.data = data;
            this.productId = productId;
            UpdateText();
        }
        public void Purchase() {
            if (!this.IsAffordable) 
                return;
            this.data.GetActualCosts().Consume();
            this.Amount += 1;
        }

        public void Update() => UpdateText();
        void UpdateText() => this.buttonLabel.text = this.IsAffordable ? $"<color=#ffffff><size=40>Costs: {this.data.GetActualCosts()}</size></color>" : 
            $"<color=#ff0000><size=40>Costs: {this.data.GetActualCosts()}</size></color>";
    }
}
