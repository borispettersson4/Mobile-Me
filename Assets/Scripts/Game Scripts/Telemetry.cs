using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Telemetry : MonoBehaviour {

    public Text mphText;
    float mph;

	
	void Update () {
        float forwardSpeed = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity).z;
        mph = forwardSpeed / 0.44704f;
        mphText.text = (int)mph + "";

    }

    public float getSpeed()
    {
        return mph;
    }
}
