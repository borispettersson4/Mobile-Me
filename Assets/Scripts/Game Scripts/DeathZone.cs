using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {

    public bool spawnDeathPlane;
    public GameObject deathPlane;

    void OnTriggerEnter(Collider col)
    {
    if(col.gameObject.tag == "Player")
        {
            if(spawnDeathPlane)
            deathPlane.SetActive(true);
        }
    }


}
