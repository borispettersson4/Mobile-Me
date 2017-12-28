using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyTrigger : MonoBehaviour {

    public Rigidbody Collider;

    public GameObject Chassis;

    void OnTriggerEnter(Collider col)
    {
        if (Chassis.GetComponent<BoxCollider>().enabled == true)
        {


            Collider.isKinematic = false;


        }
    }
}
