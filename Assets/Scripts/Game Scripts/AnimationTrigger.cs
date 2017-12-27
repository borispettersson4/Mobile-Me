using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour {

   
    public GameObject Anim;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            
            Anim.GetComponent<Animator>().enabled = true; ;
           
            
        }
    }
}
