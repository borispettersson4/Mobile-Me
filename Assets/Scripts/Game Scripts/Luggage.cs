using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luggage : MonoBehaviour {

    public GameObject cartBed;
    bool inCart = false;
    public Cart cart;
    public bool isStatic = true;

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject == cartBed)
        {
        //    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            inCart = true;
        }
        
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == cartBed)
        {
         //   RigidbodyConstraints rbc = new RigidbodyConstraints();
          //  GetComponent<Rigidbody>().constraints = rbc;
         //   GetComponent<Rigidbody>().constraints = rbc;
            inCart = false;
        }

    }
    
    void Update()
    {
        if (GetComponent<DestroyableObject>().isDestroyed() || cart.isDetached() || cart.isDestroyed())
        {
       //      transform.parent = null;
        }

        if (isInCart())
        {

        //    transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Clamp(transform.localPosition.y, 0.38f, 1), transform.localPosition.z);
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
