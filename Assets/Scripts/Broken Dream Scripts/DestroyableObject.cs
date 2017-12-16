using UnityEngine;
using System.Collections;

public class DestroyableObject : MonoBehaviour {

    public float health = 50f;
    public GameObject destroyedVersion;
    public bool destroyOnImpact = false;
    public float magnitudeCol;

    public void takeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Destroy();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(destroyOnImpact)
        Destroy();         
    }

    void Destroy()
    {
        Destroy(gameObject);
        Instantiate(destroyedVersion, transform.position,transform.rotation);
      //  destroyedVersion.transform.localScale = transform.localScale;
    }
}
