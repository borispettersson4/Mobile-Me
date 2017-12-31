using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {

public void fast()
    {
        QualitySettings.SetQualityLevel(0);
    }

    public void good()
    {
        QualitySettings.SetQualityLevel(5);
    }
}
