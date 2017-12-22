using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileOrientation : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Screen.orientation = ScreenOrientation.Landscape;

        Screen.autorotateToLandscapeLeft = true;

        Screen.autorotateToLandscapeRight = true;

        Screen.orientation = ScreenOrientation.AutoRotation;

    }
	
}
