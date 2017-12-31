using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CarInformation
{
    public float gripMultiplyer;
    public GameObject carChasisPrefab;
    public float powerMultiplyer;
}

public class CarLoader : MonoBehaviour {

    public CarInformation[] carinfos;
    public WheelGripMonitor gripMonitor;
    public CarController carCon;
    public bool updateMode = false;


	void Awake () {

        switch (PlayerPrefs.GetInt("CarData"))
        {
            case 0:
                GetComponent<MeshRenderer>().enabled = true;
                carinfos[0].carChasisPrefab.SetActive(true);
                carinfos[1].carChasisPrefab.SetActive(false);
                carinfos[2].carChasisPrefab.SetActive(false);
                gripMonitor.standardMultiplyer = carinfos[0].gripMultiplyer;
                carCon.maxMotorTorque *= carinfos[0].powerMultiplyer;
                carCon.car_Infos[0].motor = true;
                carCon.car_Infos[1].motor = true;
                break;

            case 1:
                GetComponent<MeshRenderer>().enabled = false;
                carinfos[1].carChasisPrefab.SetActive(true);
                carinfos[0].carChasisPrefab.SetActive(false);
                carinfos[2].carChasisPrefab.SetActive(false);
                gripMonitor.standardMultiplyer = carinfos[1].gripMultiplyer;
                carCon.maxMotorTorque *= carinfos[1].powerMultiplyer;
            //    carCon.car_Infos[0].motor = false;
            //    carCon.car_Infos[1].motor = true;
                break;

            case 2:
                GetComponent<MeshRenderer>().enabled = false;
                carinfos[2].carChasisPrefab.SetActive(true);
                carinfos[0].carChasisPrefab.SetActive(false);
                carinfos[1].carChasisPrefab.SetActive(false);
                gripMonitor.standardMultiplyer = carinfos[2].gripMultiplyer;
                carCon.maxMotorTorque *= carinfos[2].powerMultiplyer;
             //   carCon.car_Infos[0].motor = false;
             //   carCon.car_Infos[1].motor = true;
                break;
        }
	}

    void Update()
    {

        if (updateMode)
        {

            switch (PlayerPrefs.GetInt("CarData"))
            {
                case 0:
                    GetComponent<MeshRenderer>().enabled = true;
                    carinfos[0].carChasisPrefab.SetActive(true);
                    carinfos[1].carChasisPrefab.SetActive(false);
                    carinfos[2].carChasisPrefab.SetActive(false);
                    gripMonitor.standardMultiplyer = carinfos[0].gripMultiplyer;
                    carCon.maxMotorTorque *= carinfos[0].powerMultiplyer;
                    carCon.car_Infos[0].motor = true;
                    carCon.car_Infos[1].motor = true;
                    break;

                case 1:
                    GetComponent<MeshRenderer>().enabled = false;
                    carinfos[1].carChasisPrefab.SetActive(true);
                    carinfos[0].carChasisPrefab.SetActive(false);
                    carinfos[2].carChasisPrefab.SetActive(false);
                    gripMonitor.standardMultiplyer = carinfos[1].gripMultiplyer;
                    carCon.maxMotorTorque *= carinfos[1].powerMultiplyer;
                    //    carCon.car_Infos[0].motor = false;
                    //    carCon.car_Infos[1].motor = true;
                    break;

                case 2:
                    GetComponent<MeshRenderer>().enabled = false;
                    carinfos[2].carChasisPrefab.SetActive(true);
                    carinfos[0].carChasisPrefab.SetActive(false);
                    carinfos[1].carChasisPrefab.SetActive(false);
                    gripMonitor.standardMultiplyer = carinfos[2].gripMultiplyer;
                    carCon.maxMotorTorque *= carinfos[2].powerMultiplyer;
                    //   carCon.car_Infos[0].motor = false;
                    //   carCon.car_Infos[1].motor = true;
                    break;
            }
        }
    }


}
