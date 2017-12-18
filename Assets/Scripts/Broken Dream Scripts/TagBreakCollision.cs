using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagBreakCollision : MonoBehaviour {

    public string[] tagNames;
    public DestroyableObject destroyableObj;

    void OnTriggerEnter(Collider col)
    {
        for(int i = 0;i<tagNames.Length;i++)
    if(col.gameObject.tag == tagNames[i])
        {
            destroyableObj.die();
        }
    }
}
