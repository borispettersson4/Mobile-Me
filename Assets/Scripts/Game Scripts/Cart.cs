using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : DestroyableObject {

    ConfigurableJoint joint;
    public GameObject jointConnector;
    bool isBroken = false;


    void Awake()
    {
        joint = GetComponent<ConfigurableJoint>();
    }

    void Update()
    {
        if (!jointConnector.activeSelf)
            isBroken = true;
    }

    public bool isDetached()
    {
        return isBroken;
    }

    void OnJointBreak(float breakForce)
    {
        isBroken = true;
    }
}
