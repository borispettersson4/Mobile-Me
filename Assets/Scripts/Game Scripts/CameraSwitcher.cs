using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour {
    
    public Camera camA;
    public Camera camB;

    public void switchCameras()
    {
        camA.gameObject.SetActive(false);
        camB.gameObject.SetActive(true);
    }

}
