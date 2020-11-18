using System.Collections;
using System.Collections.Generic;
using Clicker.Player;
using Clicker.ResourceProduction;
using UnityEngine;

public class PlayersActiveProducer : MonoBehaviour
{
    public ResourceProducer activeResourceProducer;
    public PlayerData playerData;

    public void SetUp(){
        var instance = Instantiate(this.activeResourceProducer, this.transform);
        instance.SetUpPlayer(playerData.currentTrainer);
    }
}
