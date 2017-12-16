using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PcCheater : MonoBehaviour {

    public string restart, explode, spawning;
    public DestroyableObject player;
    public GameObject spawner;

	void Update () {
        if (Input.GetKey(restart))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (Input.GetKey(explode))
        {
            player.die();
        }

        if (Input.GetKey(spawning) && spawnActivator)
        {
            StartCoroutine(spawn(spawner));
        }
    }

    bool spawnActivator = true;

    IEnumerator spawn(GameObject s)
    {
        spawnActivator = false;
        s.SetActive(!s.activeSelf);
        yield return new WaitForSeconds(1f);
        spawnActivator = true;
        StopCoroutine(spawn(s));
    }
}
