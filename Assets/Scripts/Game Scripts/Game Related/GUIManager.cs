using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour {

    public GameObject gameGUI;
    public GameObject deathGUI;

    public void hideGUI()
    {
        gameGUI.SetActive(false);
    }

    public void playDeathGUI()
    {
        deathGUI.SetActive(true);
    }

}
