using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Car : System.Object
{
	public WheelCollider leftWheel;
	public GameObject leftWheelMesh;
	public WheelCollider rightWheel;
	public GameObject rightWheelMesh;
	public bool motor;
	public bool steering;
	public bool reverseTurn; 
}

public class CarController : MonoBehaviour {

	public float maxMotorTorque;
	public float maxSteeringAngle;
	public List<Car> car_Infos;

    //Mobile Controls
    public InputSimulator gas;
    public InputSimulator brake;
    public SteeringWheel wheel;
    float steering;

	public void VisualizeWheel(Car wheelPair)
	{
		Quaternion rot;
		Vector3 pos;
		wheelPair.leftWheel.GetWorldPose ( out pos, out rot);
		wheelPair.leftWheelMesh.transform.position = pos;
		wheelPair.leftWheelMesh.transform.rotation = rot;
		wheelPair.rightWheel.GetWorldPose ( out pos, out rot);
		wheelPair.rightWheelMesh.transform.position = pos;
		wheelPair.rightWheelMesh.transform.rotation = rot;
	}

	public void Update()
	{
		float motor = maxMotorTorque * (Input.GetAxis("Vertical") + gas.getAction() - brake.getAction());
	    steering = maxSteeringAngle * (Input.GetAxis("Horizontal") + wheel.GetClampedValue());
		float brakeTorque = Mathf.Abs(Input.GetAxis("Jump"));
		if (brakeTorque > 0.001) {
			brakeTorque = maxMotorTorque;
			motor = 0;
		} else {
			brakeTorque = 0;
		}

		foreach (Car car_Info in car_Infos)
		{
			if (car_Info.steering == true) {
				car_Info.leftWheel.steerAngle = car_Info.rightWheel.steerAngle = ((car_Info.reverseTurn)?-1:1)*steering;
			}

			if (car_Info.motor == true)
			{
				car_Info.leftWheel.motorTorque = motor;
				car_Info.rightWheel.motorTorque = motor;
			}

			car_Info.leftWheel.brakeTorque = brakeTorque;
			car_Info.rightWheel.brakeTorque = brakeTorque;

			VisualizeWheel(car_Info);
		}

	}

    public float getSteering()
    {
        return steering;
    }


}