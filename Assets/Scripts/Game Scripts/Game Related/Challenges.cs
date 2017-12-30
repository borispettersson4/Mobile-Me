using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Challenges : MonoBehaviour {

    public GameObject deathGUI;

    public int levelNumber; // For Player Prefs & Saving

    public bool isTraining = false;

    public GameTime time;
    public LuggerCounter luggageCount;
    public TokenCounter tokenCount;

    public Image timeStar;
    public Image luggageStar;
    public Image coinStar;

    public Sprite successStar;
    public Sprite failStar;

    //For GUI Finished

    public Text totalTime;

    public Text currentLuggage;
    public Text currentCoins;

    public Text totalLuggage;
    public Text totalCoins;

    void Awake()
    {

        if(deathGUI != null)
        {
            Destroy(deathGUI);
        }
        //Star Monitor

        if (!isTraining)
        {

            if (time.isInTime())
            {
                timeStar.sprite = successStar;
                PlayerPrefs.SetInt("timeJ" + levelNumber, 1);
            }
            else
                timeStar.sprite = failStar;

            if (luggageCount.isFull())
            {
                luggageStar.sprite = successStar;
                PlayerPrefs.SetInt("luggageJ" + levelNumber, 1);
            }
            else
                luggageStar.sprite = failStar;

            if (tokenCount.isFull())
            {
                coinStar.sprite = successStar;
                PlayerPrefs.SetInt("tokenJ" + levelNumber, 1);
            }
            else
                coinStar.sprite = failStar;
        }
        else
        {
            luggageStar.sprite = successStar;
            PlayerPrefs.SetInt("training" + levelNumber, 1);
        }

        //Tokens Add
        PlayerPrefs.SetInt("TotalTokens", tokenCount.totalTokenCount);

        //Data Transfer

        //Time
        TimeSpan timeSpan;
        timeSpan = TimeSpan.FromSeconds(time.targetTime);
        totalTime.text = string.Format("{0}:{1:00}", (int)timeSpan.TotalMinutes, timeSpan.Seconds);

        //Luggage

        currentLuggage.text = luggageCount.getLuggageCount() + "";
        totalLuggage.text = luggageCount.luggage.Length + "";

        //Tokens

        currentCoins.text = tokenCount.getTokenCount() + "";
        totalCoins.text = tokenCount.totalTokenCount + "";

        //Set the training gui so that the only star available is shown via player prefs so that the player can view progress


    }





}
