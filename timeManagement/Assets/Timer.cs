using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float seconds;
    private TimerState tState;
    public Text timerText;
    public UnitState currUnitState;

    public enum UnitState { SECONDS, MINUTES, HOURS }

    public void Start()
    {
        seconds = 0f;
        timerText.text = seconds.ToString();
    }
    public enum TimerState { UNKNOWN, STARTED,PAUSED,END }
    public void StartTimer()
    {
        tState = TimerState.STARTED;
    }
    public void PauseTimer()
    {
        
        tState = TimerState.PAUSED;
    }
    public void ResetTimer()
    {
        tState = TimerState.END;
        seconds = 0f;
        timerText.text = seconds.ToString();
    }
    public void Update()
    {
        if(tState==TimerState.STARTED)
        {
            seconds += Time.deltaTime;
            if(seconds<60)
            {
                currUnitState = UnitState.SECONDS;
                timerText.text = seconds.ToString("N2") + " Secs";
            }
            else if(seconds<3600)
            {
                currUnitState = UnitState.MINUTES;
                timerText.text = (seconds/60.0f).ToString("N2") + " Mins";
            }
            else
            {
                currUnitState = UnitState.HOURS;
                timerText.text = (seconds / 3600.0f).ToString("N2") + " Hours";
            }

            
        }
    }
}
