using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSimulator : MonoBehaviour {

    public bool isAnimated;
    Image mainImage;

    bool isDoingAction = false;

    public void doAction()
    {
        isDoingAction = true;
    }

    public void stopAction()
    {
        isDoingAction = false;
    }

    public int getAction()
    {
        if (isDoingAction)
            return 1;
        else
            return 0;
    }
}
