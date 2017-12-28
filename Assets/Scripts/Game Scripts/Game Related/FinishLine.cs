using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour {


    public GUIManager manager;
    public Player player;
    bool isInLine = false;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Car" && !player.isDestroyed())
        {
            isInLine = true;
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Car" && !player.isDestroyed())
        {
            isInLine = false;
        }

    }

    void Update()
    {
        if(player.GetComponent<Telemetry>().getSpeed() < 1 && isInLine)
        {
            finish();
        }
    }

    void finish()
    {
        isInLine = false;
        manager.hideGUI();
        manager.playFinishGUI();
    }
}

public class TouchControl : MonoBehaviour
{


    public KeyCode A;

    public Button TouchCtrl;

    void Start()
    {
        TouchCtrl = GetComponent<Button>();
    }

    void Update()
    {
        if (Input.GetButton("Jump"))
        {

        }
    }


} //End
