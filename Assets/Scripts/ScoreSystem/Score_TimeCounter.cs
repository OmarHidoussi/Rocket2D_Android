using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_TimeCounter : MonoBehaviour
{

    #region Variables

    public TextMeshProUGUI timerText;
    [HideInInspector] public float secondsCount;
    private int minuteCount;
    private int hourCount;

    #endregion

    #region BuiltInMethods

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        UpdateTimerUI();
    }

    #endregion

    #region CustomMethods

    public void UpdateTimerUI()
    {
        secondsCount += Time.deltaTime;

        string SecondsCounter;
        string MinutesCounter;
        
        if(secondsCount > 9.5f)
        {
            float newSecondCounter = secondsCount;
            SecondsCounter = newSecondCounter.ToString("0");
        }
        else
        {
            SecondsCounter = "0" + secondsCount.ToString("0");
        }

        if(minuteCount > 9)
        {
            MinutesCounter = minuteCount.ToString();
        }
        else
        {
            MinutesCounter ="0" + minuteCount.ToString();
        }

        timerText.text = hourCount +":"+ MinutesCounter +":"+SecondsCounter;


        if(secondsCount >= 59)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if(minuteCount >= 59)
        {
            hourCount++;
            minuteCount = 0;
        }
    }

    #endregion

}
