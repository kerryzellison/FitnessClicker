using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DaySystemScript : MonoBehaviour
{
    public Text caloriesOfflineText;
    public Text timeText;
    private string currentTime;
    private int interval = 1;
    private float _nextTime = 0;
    void Start()
    {
        
        if (PlayerPrefs.HasKey("LAST_ONLINE"))
        {
            DateTime lastOnline = DateTime.Parse(PlayerPrefs.GetString("LAST_ONLINE"));

            TimeSpan timeSpanOffline = DateTime.Now - lastOnline;
            
            PlayerPrefs.DeleteKey("LAST_ONLINE"); //remove when building!
        }
        else
        {
            Debug.Log("WELCOME");
        }
    }

    private void FixedUpdate()
    {
        if (Time.time >= _nextTime)
        {
            
            UpdateTimeEverySec();
            _nextTime += interval;
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("LAST_ONLINE",DateTime.Now.ToString());
    }

    void OnApplicationStart()
    {
        PlayerPrefs.SetString("LAST_OFFLINE",DateTime.Now.ToString());
    }

    void UpdateTimeEverySec()
    {
        currentTime = DateTime.Now.ToString();
    }

    void CountTimeOnline()
    {
        //TODO
    }
    
}
