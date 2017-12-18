using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luggage : MonoBehaviour {

    public GameObject cartBed;
    bool inCart = false;
    public Cart cart;

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == cartBed)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            inCart = true;
        }
        
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == cartBed)
        {
            RigidbodyConstraints rbc = new RigidbodyConstraints();
            GetComponent<Rigidbody>().constraints = rbc;
            GetComponent<Rigidbody>().constraints = rbc;
            inCart = false;
        }

    }
    
    void Update()
    {
        if (GetComponent<DestroyableObject>().isDestroyed() || cart.isDetached() || cart.isDestroyed())
        {
             transform.parent = null;
        }
    }

    public bool isInCart()
    {
        if (!GetComponent<DestroyableObject>().isDestroyed() && !cart.isDetached() && !cart.isDestroyed())
            return inCart;
        else
            return false;
    }
}
