using System.Runtime.CompilerServices;
using Resources;
using UnityEngine;

namespace Clicker.ResourceProduction {
    [CreateAssetMenu(menuName = "Clicker/Resource production unit/Trainer", fileName = "New trainer data")] // "ResourceProductionData"
    public class Data : ScriptableObject {
        [SerializeField] ResourceAmount costs;
        public float productionTime = 1f;
        [SerializeField] ResourceAmount production;
        public string id;
        public ResourceAmount GetActualCosts() {
            var result = this.costs;
            return result;
        }
        public ResourceAmount GetProductionAmount() {
            var result = this.production;
            return result;
        }
    }
}