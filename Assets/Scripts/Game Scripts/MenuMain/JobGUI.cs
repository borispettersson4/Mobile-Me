using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobGUI : MonoBehaviour {

    //This script would pass over level completion data auch as star status for the three stars using player prefs

    //Training levels would only have one star named "Aproved"

    public Image timeStar;
    public Image luggageStar;
    public Image coinStar;

    public Sprite successStar;
    public Sprite failStar;

    public int levelNumber;

    void Awake()
    {
        if (PlayerPrefs.GetInt("timeJ" + levelNumber) == 1)
        {
            timeStar.sprite = successStar;
        }
        else
            timeStar.sprite = failStar;

        if (PlayerPrefs.GetInt("luggageJ" + levelNumber) == 1)
        {
            luggageStar.sprite = successStar;
        }
        else
            luggageStar.sprite = failStar;

        if (PlayerPrefs.GetInt("tokenJ" + levelNumber) == 1)
        {
            coinStar.sprite = successStar;
        }
        else
            coinStar.sprite = failStar;


    }

}
