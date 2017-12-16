using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PcCheater : MonoBehaviour {

    public string restart, explode;
    public DestroyableObject player;
	void Update () {
        if (Input.GetKey(restart))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (Input.GetKey(explode))
        {
            player.die();
        }
    }
}
