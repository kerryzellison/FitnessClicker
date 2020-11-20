using System.Collections.Generic;
using Clicker.Player;
using UnityEngine;

namespace Clicker.ResourceProduction {
    public class Setup : MonoBehaviour {

        public List<Data> datas;
        public ResourceProducer trainerPrefab;
        public PlayerData playerData;
        public int numbersToDisplay = 0;

        void Start(){
            numbersToDisplay = 0;
            foreach (var productionUnit in this.datas) {
                if (numbersToDisplay >= 8){
                    var instance = Instantiate(this.trainerPrefab, this.transform);
                    productionUnit.id = productionUnit.name;
                    instance.SetUp(productionUnit,this);
                    instance.gameObject.SetActive(false);
                }
                if (numbersToDisplay < 8){
                    if (playerData.usedTrainers.Contains(productionUnit.name)){
                        Debug.Log($"This productionUnit is skipped, {productionUnit.name}");
                    }
                    else{
                        var instance = Instantiate(this.trainerPrefab, this.transform);
                        productionUnit.id = productionUnit.name;
                        instance.SetUp(productionUnit,this);
                        numbersToDisplay += 1;
                    } 
                }
            }
        }
        public void ActivateNextInLine(){
            foreach (Transform child in this.gameObject.transform){
                if(child.gameObject.activeSelf)
                {
                    Debug.Log($"The child {child.name} is active!");
                }
                else
                {
                    child.transform.gameObject.SetActive(true);
                    return;
                }
            }
        }
    }
}