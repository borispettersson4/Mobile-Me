using UnityEngine;
using System.Collections;

public class DestroyableObject : MonoBehaviour {


    public float magnitudeCol;
    float currentSpeed;
    public float explosionForce = 10f;
    protected bool isDead = false;
    public int layerNumber = 0;
    public bool isParentTrigger = false;
    
    void OnCollisionEnter(Collision collision)
    {
        currentSpeed = collision.relativeVelocity.magnitude;
        if (collision.relativeVelocity.magnitude > magnitudeCol && collision.gameObject.layer == layerNumber && !isParentTrigger)
        {

            Debug.Log(collision.gameObject.name);

            foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
                if (GetComponentsInChildren<Rigidbody>() != null)
                {
                    rb.isKinematic = false;
                    rb.velocity = -collision.relativeVelocity ;
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
            isDead = true;
        }

        else if (collision.relativeVelocity.magnitude > magnitudeCol && collision.gameObject.layer == layerNumber && isParentTrigger)
        {
            foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
                if (GetComponentsInChildren<Rigidbody>() != null)
                {
                    rb.isKinematic = false;
                    GetComponentInParent<DestroyableObject>().die();
                    rb.velocity = -collision.relativeVelocity;
                    rb.AddForce(rb.transform.up * magnitudeCol * explosionForce);
                }

            foreach (Collider col in GetComponentsInChildren<Collider>())
                if (GetComponentsInChildren<Collider>() != null)
                    col.enabled = true;

      //      transform.DetachChildren();
     //       die();
            isDead = true;
        }
    }

    public void die()
    {
        isDead = true; 

        if(GetComponent<CameraSwitcher>() != null)
        {
            GetComponent<CameraSwitcher>().switchCameras();
        }

        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
            if (GetComponentsInChildren<Rigidbody>() != null)
            {
                rb.isKinematic = false;
        //        rb.velocity = rb.transform.forward * currentSpeed;
          //      rb.AddForce(rb.transform.forward*currentSpeed*explosionForce);
            }

        foreach (WheelCollider col in GetComponentsInChildren<WheelCollider>())
            if (GetComponentsInChildren<WheelCollider>() != null)
                col.enabled = false;

        foreach (Collider col in GetComponentsInChildren<Collider>())
            if (GetComponentsInChildren<Collider>() != null)
                col.enabled = true;

        transform.DetachChildren();
    }

    public bool isDestroyed()
    {
        return isDead;
    }

}


