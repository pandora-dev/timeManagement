using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;


public class AppLogic : MonoBehaviour {

    public Button startPauseButton;
    public Timer timer;
    public TMPro.TextMeshProUGUI inputText;
    public TMPro.TextMeshProUGUI latestFive;

    public Text buttonText;
    private TimerButtonBehaviour StartPauseButtonBehaviour;

    public void Start()
    {
        Application.runInBackground = true;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        StartPauseButtonBehaviour = startPauseButton.GetComponent<TimerButtonBehaviour>();
    }

    public void startPauseButtonAction()
    {
        
        if (StartPauseButtonBehaviour.currBehaviour==TimerButtonBehaviour.ButtonBehaviour.START)
        {
            StartPauseButtonBehaviour.ChangeBehaviour();
            timer.StartTimer();
            
        }
        else if(StartPauseButtonBehaviour.currBehaviour == TimerButtonBehaviour.ButtonBehaviour.PAUSE)
        {
            StartPauseButtonBehaviour.ChangeBehaviour();
            timer.PauseTimer();
            
        }
        
    }

    public void endButtonAction()
    {
        if(StartPauseButtonBehaviour.currBehaviour==TimerButtonBehaviour.ButtonBehaviour.PAUSE)
            StartPauseButtonBehaviour.ChangeBehaviour();
        InsertRow();
        timer.ResetTimer();
    }

    public void InsertRow()
    {
        StartCoroutine(InsertRowRoutine());
    }



    IEnumerator InsertRowRoutine()
    {
        WWWForm form = new WWWForm();
        form.AddField("seconds", timer.seconds.ToString());
        form.AddField("row_record", inputText.text);

        using (UnityWebRequest www = UnityWebRequest.Post("https://www.arpandora.com/timeManagement/index.php/records/insert_raw_row/",form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Successfully posted!");


                latestFive.text=www.downloadHandler.text.Replace("\\n","\n");
                
            }

        }
    }






}
