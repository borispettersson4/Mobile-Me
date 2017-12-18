using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameTime : MonoBehaviour {

    public Text timerGUI;
    public int time = 30;
    TimeSpan timeSpan;

    void Awake()
    {
        timeSpan = TimeSpan.FromSeconds(time);
        StartCoroutine(countDown());
    }

    void Update()
    {
        string timeFormat = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds); 

        timerGUI.text = string.Format("{0}:{1:00}",(int)timeSpan.TotalMinutes, timeSpan.Seconds);
    }

    IEnumerator countDown()
    {
        yield return new WaitForSeconds(1);
        timeSpan = timeSpan.Add(TimeSpan.FromSeconds(1));
        StartCoroutine(countDown());
    }

    public void timerStop()
    {
        StopCoroutine(countDown());
    }

}
