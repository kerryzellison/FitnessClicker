using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DaySystemScript : MonoBehaviour
{
    public class DateTimeTest : MonoBehaviour{
        long GetEpochTimeMilliseconds(){
            DateTime startOfTime = new DateTime(1970, 1, 1, 0, 0, 0);
            var time = Convert.ToInt64(DateTime.UtcNow.Subtract(startOfTime).TotalMilliseconds);
            return time;
        }

        public long lastCalorieBurnTime;
        public void Start(){
            lastCalorieBurnTime = GetEpochTimeMilliseconds();
        }

        void Update(){
            var millisecondsPassed = GetEpochTimeMilliseconds() - lastCalorieBurnTime;
            var secondsPassed = millisecondsPassed / 1000;
            if (secondsPassed >= 60 * 30){ // 60 sec * 30 = 30 minutes.
                lastCalorieBurnTime = GetEpochTimeMilliseconds(); // reset the timer.
            }
            Debug.Log(secondsPassed.ToString());
        }
    }

   
}
