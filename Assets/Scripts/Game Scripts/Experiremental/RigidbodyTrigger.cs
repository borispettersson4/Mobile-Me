using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyTrigger : MonoBehaviour {

    public Rigidbody RigidObj;

    public GameObject Chassis;

    void OnTriggerEnter(Collider col)
    {
        if (Chassis.GetComponent<BoxCollider>().enabled == true)
        {


            RigidObj.isKinematic = false;


        }
    }
}
