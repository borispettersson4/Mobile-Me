using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCol : MonoBehaviour {

    public Collider[] collidersToIgnore;
	void Start () {
		for(int i = 0;i < collidersToIgnore.Length; i++)
        {
            Physics.IgnoreCollision(collidersToIgnore[i], GetComponent<Collider>());
        }
	}
}
