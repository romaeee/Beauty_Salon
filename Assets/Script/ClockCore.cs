using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockCore : MonoBehaviour
{    
    public Text timeText;
    public Text dayText;

    public string timePeriod = "AM";
    public float param;
    public float hour = 10;
    public float minuts = 0;

    void Update()
    {
        if (hour != 8)
        {
            param += Time.deltaTime * 2;
        }

        if (param < 60)
        {
            minuts = param;
        }
        else if (param >= 60)
        {
            hour += 1;
            param = 0;
        }

        if (hour > 12)
        {
            hour = 1;
        }

        if (hour >= 10 && hour <= 11)
        {
            timePeriod = "AM";
        }
        else if (hour >=0 && hour < 10)
        {
            timePeriod = "PM";
        }

        timeText.text = Mathf.Round(hour).ToString() + ":" + Mathf.Round(minuts).ToString("00") + timePeriod;

        dayText.text = "DAY: " + GameManager.day.ToString();

        if (hour != 8)
        {
            GameManager.workingDay = true;
        }
        else
        {
            GameManager.workingDay = false;
        }
    }
}
