using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour {

    public TokenCounter tokenCounter;
    bool active = true;

    void OnTriggerEnter(Collider col)
    {
    if(col.gameObject.tag == "Car" && active)
        {
            active = false;
            Destroy(gameObject);
            tokenCounter.addTokens(1);
        }
        
    }
}
