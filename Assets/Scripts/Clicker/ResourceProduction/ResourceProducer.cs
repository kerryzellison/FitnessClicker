using UnityEngine;
using UnityEngine.UI;

namespace Clicker.ResourceProduction {
    public class ResourceProducer : MonoBehaviour {
        public Data data;
        public Text titleText;
        public Purchasable amount;
        float elapsedTime;
        public string id;
        public void SetUp(Data data) {
            this.data = data;
            this.id = data.id;
            this.gameObject.name = data.name;
            this.titleText.text = this.ToString();
            this.amount.SetUp(data, "Count"); // this is the unit amount count
        }
        public void Purchase() => this.amount.Purchase();

        void Update() {
            UpdateProduction();
            amount.Update();
        }

        void UpdateProduction() {
            this.elapsedTime += Time.deltaTime;
            if (this.elapsedTime >= this.data.productionTime) {
                Produce();
                this.elapsedTime -= this.data.productionTime;
            }
        }

        public override string ToString(){
            return $"<color=#ffffff><size=45>{this.data.name}:</size></color> \n" +
                   $"<color=#000000><size=35>Produces {this.data.GetProductionAmount()} calorie per {this.data.productionTime / 60} minutes.</size></color>\n" +
                   $"<color=#ffffff><size=40>Costs: {this.data.GetActualCosts()}</size></color>";
        }

        void Produce() {
            if (this.amount.Amount == 0)
                return;
            var productionAmount = this.data.GetProductionAmount();
            productionAmount.Create();
        }
    }
}