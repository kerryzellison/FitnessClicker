using System;
using System.Collections;
using System.Collections.Generic;
using Clicker.Player;
using Clicker.ResourceProduction;
using UnityEngine;

public class PlayersActiveProducer : MonoBehaviour
{
    public ResourceProducer activeResourceProducerPrefab;
    public PlayerData playerData;
    public void SetUp(){
        var instance = Instantiate(this.activeResourceProducerPrefab, this.transform);
        instance.SetUpPlayer(playerData.currentTrainer);
        instance.gameObject.name = playerData.currentTrainer.name;
    }
}
