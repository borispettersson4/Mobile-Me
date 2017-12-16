using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telemetry : MonoBehaviour {

	
	void Update () {
        float forwardSpeed = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity).z;
        float mph = forwardSpeed / 0.44704f;
        float kph = mph / 1.6f;
        Debug.Log("SPEED : " + mph + " MPH " + mph + " KPH");
	}
}
