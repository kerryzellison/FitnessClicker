using System.Collections.Generic;
using Clicker.Player;
using UnityEngine;

namespace Clicker.ResourceProduction {
    public class Setup : MonoBehaviour {

        public List<Data> datas;
        public ResourceProducer trainerPrefab;
        public PlayerData playerData;

        void Start() {
            foreach (var productionUnit in this.datas) {
                if (playerData.usedTrainers.Contains(productionUnit.name)){
                        Debug.Log($"This productionUnit is skipped, {productionUnit.name}");
                }
                else{
                    var instance = Instantiate(this.trainerPrefab, this.transform);
                    productionUnit.id = productionUnit.name;
                    instance.SetUp(productionUnit,this);
                }
            }
        }
    }
}