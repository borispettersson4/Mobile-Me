using UnityEngine;
using System.Collections;

public class DestroyableObject : MonoBehaviour {


    public float magnitudeCol;
    float speed;
    Vector3 moveDirection;
    

    void Awake()
    {
        speed = GetComponent<Rigidbody>().velocity.magnitude;
        moveDirection = GetComponent<Transform>().forward;
    }
 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > magnitudeCol && collision.gameObject.layer == 0)
        {
            foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
                if (GetComponentsInChildren<Rigidbody>() != null)
                {
                    rb.isKinematic = false;
                    rb.velocity = collision.relativeVelocity/2;
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

        Debug.Log(collision.gameObject.name);
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


