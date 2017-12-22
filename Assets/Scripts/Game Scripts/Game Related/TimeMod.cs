using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMod : MonoBehaviour {

    public float timeScale = 1;
    public bool setAwake = false;

    public void setTimeScale(int x)
    {
        Time.timeScale = x;
        setAwake = true;
    }
	
	void Update () {
     //   if(setAwake)
    //    Time.timeScale = timeScale;
	}
}
