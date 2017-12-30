using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalTokens : MonoBehaviour {

    public Text countGUI;
	void Update () {

        countGUI.text = PlayerPrefs.GetInt("TotalTokens") + "";

	}
}
