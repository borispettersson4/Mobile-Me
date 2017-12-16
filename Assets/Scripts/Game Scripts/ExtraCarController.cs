using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraCarController : MonoBehaviour
{

    public CarController controller;
    float torqueSpeed;

    void Awake()
    {
        torqueSpeed = controller.maxMotorTorque;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<SpeedBoost>() != null)
        {
            controller.maxMotorTorque = torqueSpeed + col.gameObject.GetComponent<SpeedBoost>().speedBoostAmount;
        }
    }


    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.GetComponent<SpeedBoost>() != null)
        {
            controller.maxMotorTorque = torqueSpeed;
        }
    }
}

