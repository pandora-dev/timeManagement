using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerButtonBehaviour : MonoBehaviour {

    public ButtonBehaviour currBehaviour;
    public enum ButtonBehaviour { START,PAUSE }
    public Text buttonText;

    public void Start()
    {
        currBehaviour = ButtonBehaviour.START;
        buttonText.text = "START";
    }

    public void ChangeBehaviour()
    {
        if (currBehaviour == ButtonBehaviour.START)
        {
            currBehaviour = ButtonBehaviour.PAUSE;
            buttonText.text = "PAUSE";
        }
        else
        {
            currBehaviour = ButtonBehaviour.START;
            buttonText.text = "START";
        }
            
    }

}
