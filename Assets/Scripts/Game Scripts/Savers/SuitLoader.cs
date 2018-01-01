using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SuitInformation
{
    public GameObject hatPrefab;
    public Mesh suitMesh;
}

public class SuitLoader : MonoBehaviour
{

    public SuitInformation[] suitinfos;
    public int testInt = 0;


    void Update()
    {

        switch (PlayerPrefs.GetInt("SuitData"))
        {
            case 0:
                GetComponent<SkinnedMeshRenderer>().sharedMesh = suitinfos[0].suitMesh;
                suitinfos[0].hatPrefab.SetActive(true);
                suitinfos[1].hatPrefab.SetActive(false);
                break;

            case 1:
                GetComponent<SkinnedMeshRenderer>().sharedMesh = suitinfos[1].suitMesh;
                suitinfos[1].hatPrefab.SetActive(true);
                suitinfos[0].hatPrefab.SetActive(false);
                break;
        }
    }


}
