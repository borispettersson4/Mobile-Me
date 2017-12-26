using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {


    public GUIManager manager;
    public Player player;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Car" && !player.isDestroyed() & player.isStill())
        {
            manager.hideGUI();
            manager.playFinishGUI();
        }

    }

}
