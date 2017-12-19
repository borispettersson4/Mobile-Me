using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {


    public GUIManager manager;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Car")
        {
            manager.hideGUI();
            manager.playFinishGUI();
        }

    }

}
