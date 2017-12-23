using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSFX : MonoBehaviour {

    public DestroyableObject car;
    public Telemetry telemetry;
    public CarController carCon;

    public AudioSource engine;
    public AudioSource tires;
    public AudioSource crash;

    bool activeOnce = true;

    void Update()
    {
        if(car.isDestroyed() && activeOnce)
        {
            activeOnce = false;
            crash.Play();
        }

        engine.pitch = Mathf.Clamp((Mathf.Abs(telemetry.getSpeed())/10f),0.5f,3);

        if (telemetry.getSpeed() > 15 && Mathf.Abs(carCon.getSteering()) > 0.5f)
            tires.pitch = Mathf.Clamp((Mathf.Abs(telemetry.getSpeed() / 10f) * Mathf.Abs(carCon.getSteering())) / 30, 1, 3);
        else
            tires.pitch = 0;
    }
}
