using System.Collections.Generic;
using UnityEngine;

namespace Clicker.ResourceProduction {
    public class Setup : MonoBehaviour {

        public List<Data> datas;
        public ResourceProducer trainerPrefab;

        void Start() {
            foreach (var productionUnit in this.datas) {
                var instance = Instantiate(this.trainerPrefab, this.transform);
                productionUnit.id = productionUnit.name;
                instance.SetUp(productionUnit,this);
            }
        }
    }
}