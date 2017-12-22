using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour {
    
    public Camera cam;
    public Transform a;

    public void switchCameras()
    {
        cam.GetComponent<SmoothFollow2>().target = a;
        cam.GetComponent<SmoothFollow2>().rotationDamping = 0;

    }

}
