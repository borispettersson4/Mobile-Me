using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMod : MonoBehaviour {

    public float timeScale = 1;
	
	void Update () {
        Time.timeScale = timeScale;
	}
}
