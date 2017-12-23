using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingGUI : MonoBehaviour {

    //This script would pass over level completion data auch as star status for the three stars using player prefs

    //Training levels would only have one star named "Aproved"

    public Image star;

    public Sprite successStar;
    public Sprite failStar;

    public int levelNumber;

    void Awake()
    {
        if (PlayerPrefs.GetInt("training" + levelNumber) == 1)
        {
            star.sprite = successStar;
        }
        else
            star.sprite = failStar;
    }

}
