using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraCarController : MonoBehaviour
{

    public CarController controller;
    float torqueSpeed;
    bool rotFreeze = false;

    void Update()
    {
        if (rotFreeze)
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
            gameObject.GetComponent<Rigidbody>().rotation = new Quaternion(GetComponent<Rigidbody>().rotation.x, GetComponent<Rigidbody>().rotation.y, Mathf.Clamp(GetComponent<Rigidbody>().rotation.z, 0.0f, 0.2f), GetComponent<Rigidbody>().rotation.w);
        }
        else
            gameObject.GetComponent<Rigidbody>().freezeRotation = false;

        Debug.Log(GetComponent<Rigidbody>().rotation);
    }

    void Awake()
    {
        torqueSpeed = controller.maxMotorTorque;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<SpeedBoost>() != null)
        {
            controller.maxMotorTorque = torqueSpeed + col.gameObject.GetComponent<SpeedBoost>().speedBoostAmount;
            StartCoroutine(freezeRot());
        }
    }


    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.GetComponent<SpeedBoost>() != null)
        {
            controller.maxMotorTorque = torqueSpeed;
        }
    }

    IEnumerator freezeRot()
    {
        yield return new WaitForSeconds(0.6f);
        rotFreeze = true;
        yield return new WaitForSeconds(1f);
        rotFreeze = false;
    }
}

