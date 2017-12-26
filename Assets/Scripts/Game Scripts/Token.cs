using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour {

    public TokenCounter tokenCounter;
    public AudioSource gainSound;
    bool active = true;

    void OnTriggerEnter(Collider col)
    {
    if(col.gameObject.tag == "Car" && active)
        {
            gainSound.Play();
            active = false;
            Destroy(gameObject);
            tokenCounter.addTokens(1);
        }
        
    }
}
