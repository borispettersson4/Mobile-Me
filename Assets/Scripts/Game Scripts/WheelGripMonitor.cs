using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarController))]
public class WheelGripMonitor : MonoBehaviour
{

    
    public Surface[] surfaces;
    CarController carCon;
    public WheelCollider[] wheels;

    float sideWaysGrip;
    float frontGrip;

    public float standardMultiplyer = 1;

    WheelFrictionCurve wfc = new WheelFrictionCurve();

    void Awake()
    {
        carCon = GetComponent<CarController>();

        //Get grip levels
        for (int i = 0; i < wheels.Length; i++)
        {
           sideWaysGrip = wheels[i].sidewaysFriction.stiffness * standardMultiplyer;
           frontGrip = wheels[i].forwardFriction.stiffness * standardMultiplyer;
        }
    }

    void Update()
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            WheelHit hit;
            if (wheels[i].GetGroundHit(out hit))
            {
                if (hasSurface(hit.collider.gameObject.tag))
                {
                    wfc = wheels[i].sidewaysFriction;
                    wfc.stiffness = Mathf.Clamp(sideWaysGrip - getSurface(hit.collider.gameObject.tag).gripLoss,0,1);
                    wheels[i].sidewaysFriction = wfc;

                    wfc = wheels[i].forwardFriction;
                    wfc.stiffness = Mathf.Clamp(frontGrip - getSurface(hit.collider.gameObject.tag).gripLoss, 0, 1);
                    wheels[i].forwardFriction = wfc;
                }
                else
                {
                    wfc = wheels[i].sidewaysFriction;
                    wfc.stiffness = sideWaysGrip;
                    wheels[i].sidewaysFriction = wfc;
                    wfc = wheels[i].forwardFriction;
                    wfc.stiffness = frontGrip;
                    wheels[i].forwardFriction = wfc;
                }
            }
        }
    }

    bool hasSurface(string s)
    {
        bool temp = false;

        for (int i = 0; i < surfaces.Length; i++)
        {
            if (surfaces[i].name == s)
                temp = true;
        }

        return temp;
    }

    Surface getSurface(string s)
    {
        for (int i = 0; i < surfaces.Length; i++)
        {
            if (surfaces[i].name == s)
            {
                return surfaces[i];
            }
        }

        return new Surface();
    }
}
[System.Serializable]
public struct Surface
{
    public string name;
    public float gripLoss;

}
