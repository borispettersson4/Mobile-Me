using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toll : MonoBehaviour {

    public TokenCounter tokenCounter;
    public Animation animationClip;
    public Player player;
    public float tokenCount;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player.gameObject)
        {
            if (tokenCounter.getTokenCount() >= tokenCount)
            {
                GetComponent<Animator>().Play(animationClip.name);
            }
        }
    }
}
