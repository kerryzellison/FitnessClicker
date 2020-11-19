using Clicker.Player;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Clicker.ResourceProduction {
    public class ResourceProducer : MonoBehaviour {
        public Data data;
        public Text titleText;
        public Text ActiveLabel;
        public Purchasable amount;
        float elapsedTime;
        public string id;
        public void SetUp(Data data, Setup trainerSetup) {
            this.data = data;
            this.id = data.id;
            this.gameObject.name = data.name;
            this.titleText.text = this.ToString();
            this.amount.SetUp(data, "Count",trainerSetup, this); // this is the unit amount count
        }
        public void SetUpPlayer(Data data) {
            this.data = data;
            this.id = data.id;
            this.gameObject.name = data.name;
            this.titleText.text = this.ToString();
            this.amount.SetUpPlayer(data, "CountPlayer"); // this is the unit amount count
        }

        public void Purchase() => this.amount.Purchase();

        void Update() {
            UpdateProduction();
            amount.Update();
            UpdateActiveText();
        }
        void UpdateProduction() {
            this.elapsedTime += Time.deltaTime;
            if (this.elapsedTime >= this.data.productionTime) {
                Produce();
                this.elapsedTime -= this.data.productionTime;
            }
        }

        public void UpdateActiveText(){
            this.ActiveLabel.text = $"<color=#FDFF00><size=50>{this.data.name}:</size></color> \n" +
                                    $"<color=#323232><size=35>Burns {this.data.GetProductionAmount()} calories\neach minute</size></color>\n" +
                                    $"<color=#FDFF00><size=45>Price was: {this.data.GetActualCosts()}</size></color>";
        }
        public override string ToString(){
            return $"<color=#FDFF00><size=45>{this.data.name}:</size></color> \n" +
                   $"<color=#323232><size=35>Burns {this.data.GetProductionAmount()} calories each minute</size></color>\n" +
                   $"<color=#FDFF00><size=40>Costs: {this.data.GetActualCosts()}</size></color>";
        }

        public void DestroyThisResourceProducer(){
            Destroy(this.gameObject);
        }
        void Produce() {
            if (this.amount.Amount == 0)
                return;
            var productionAmount = this.data.GetProductionAmount();
            productionAmount.Create();
        }
    }
}