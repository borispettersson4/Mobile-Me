using UnityEngine;
using System.Collections;

public class DestroyableObject : MonoBehaviour {


    public float magnitudeCol;
    float speed;
    Vector3 moveDirection;
    float currentSpeed;
    public float explosionForce = 10f;
    

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
                    rb.velocity = collision.relativeVelocity / 2;
                    rb.AddForce(rb.transform.forward * magnitudeCol * explosionForce);
                }

            foreach (WheelCollider col in GetComponentsInChildren<WheelCollider>())
                if (GetComponentsInChildren<WheelCollider>() != null)
                    col.enabled = false;

            foreach (Collider col in GetComponentsInChildren<Collider>())
                if (GetComponentsInChildren<Collider>() != null)
                    col.enabled = true;

            transform.DetachChildren();
            //   Destroy(gameObject, 0.2f);
        }
    }

    public void die()
    {
        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
            if (GetComponentsInChildren<Rigidbody>() != null)
            {
                rb.isKinematic = false;
                rb.AddForce(rb.transform.forward*currentSpeed*explosionForce);
            }

        foreach (WheelCollider col in GetComponentsInChildren<WheelCollider>())
            if (GetComponentsInChildren<WheelCollider>() != null)
                col.enabled = false;

        foreach (Collider col in GetComponentsInChildren<Collider>())
            if (GetComponentsInChildren<Collider>() != null)
                col.enabled = true;

        transform.DetachChildren();
    }



    public Vector3 Velocity
    {

        get
        {
            return speed * moveDirection;
        }

        set
        {
            speed = value.magnitude;
            moveDirection = value.normalized;
        }
    }

}


