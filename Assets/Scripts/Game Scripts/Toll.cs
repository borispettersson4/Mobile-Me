using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toll : MonoBehaviour {

    public TokenCounter tokenCounter;
    public Animation animationClip;
    public float tokenCount;

    bool active1 = true;

    void Update()
    {
        if(tokenCounter.getTokenCount() >= tokenCount && active1)
        {
            active1 = false;
            GetComponent<Animator>().Play(animationClip.name);
        }
    }
}
