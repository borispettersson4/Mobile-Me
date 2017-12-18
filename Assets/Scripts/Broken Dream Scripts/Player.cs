using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{


    public float magnitudeCol;
    float speed;
    Vector3 moveDirection;
    float currentSpeed;
    public float explosionForce = 10f;
    public Collider frontImpactCol;
    public Collider[] InstaColliders;


    void Awake()
    {
        speed = GetComponent<Rigidbody>().velocity.magnitude;
        moveDirection = GetComponent<Transform>().forward;
    }

    void OnCollisionEnter(Collision collision)
    {
        currentSpeed = collision.relativeVelocity.magnitude;
        if (collision.relativeVelocity.magnitude > magnitudeCol && collision.gameObject.layer == 0)
        {

            Debug.Log(collision.gameObject.name);

            foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
                if (GetComponentsInChildren<Rigidbody>() != null)
                {
                    rb.isKinematic = false;
                    rb.velocity = -collision.relativeVelocity;
                    rb.AddForce(rb.transform.up * magnitudeCol * explosionForce);
                }

            foreach (WheelCollider col in GetComponentsInChildren<WheelCollider>())
                if (GetComponentsInChildren<WheelCollider>() != null)
                    col.enabled = false;

            foreach (Collider col in GetComponentsInChildren<Collider>())
                if (GetComponentsInChildren<Collider>() != null)
                    col.enabled = true;

            transform.DetachChildren();
            die();
        }
    }

    public void die()
    {
        if (GetComponent<CameraSwitcher>() != null)
        {
            GetComponent<CameraSwitcher>().switchCameras();
        }

        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
            if (GetComponentsInChildren<Rigidbody>() != null)
            {
                rb.isKinematic = false;
                rb.AddForce(rb.transform.forward * currentSpeed * explosionForce);
            }

        foreach (WheelCollider col in GetComponentsInChildren<WheelCollider>())
            if (GetComponentsInChildren<WheelCollider>() != null)
                col.enabled = false;

        foreach (Collider col in GetComponentsInChildren<Collider>())
            if (GetComponentsInChildren<Collider>() != null)
                col.enabled = true;

        transform.DetachChildren();
    }

    public bool isStill()
    {
        return (gameObject.GetComponent<Rigidbody>().velocity.magnitude <= 0.2f);
    }


}


