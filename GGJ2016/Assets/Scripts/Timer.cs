using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerLabel;
    public float time = 180;
    int minutes;
    int seconds;
    int fraction;
    bool start = false;

    void Start()
    {
        StartTimer();
    }

    void Update()
    {

        if (start)
        {
            time -= Time.deltaTime;
        }
        //Debug.Log (time);
        minutes = (int)time / 60; //Divide the guiTime by sixty to get the minutes.
        seconds = (int)(time - minutes * 60);//Use the euclidean division for the seconds.

        //update the label value
        timerLabel.text = string.Format("{0:0} : {1:00}", minutes, seconds);

        if (time <= 0)
        {
            StopTimer();
            notifyLost();

        }
    }

    public void StartTimer()
    {
        start = true;
    }

    public void StopTimer()
    {
        start = false;
    }

    public float GetTimeFloat()
    {
        return minutes * 60f + seconds + fraction / 1000f;
    }

    public string GetTimeText()
    {
        return timerLabel.text;
    }

    public void notifyLost()
    {
        GameManager.Instance.showLostMessage();
    }
}
