using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Telemetry : MonoBehaviour {

    public Text mphText;

	
	void Update () {
        float forwardSpeed = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity).z;
        float mph = forwardSpeed / 0.44704f;
        float kph = mph / 1.6f;
        mphText.text = "SPEED : " + (int)mph + " MPH";

    }
}
