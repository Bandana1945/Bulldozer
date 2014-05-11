using UnityEngine;
using System.Collections;

public class BulldozerBehaviour : MonoBehaviour {
	int SetValueCounter=0;
	int Camera_MovingCounter=1;
	float Torque_Wheel=0;
	float Steer=0;
	float BackPower=0;
	bool W,A,D,SPACE,L_SHIFT=false;
	// Use this for initialization
	void Start () {
		SetValueToPublic_Value_First ();
		rigidbody.centerOfMass = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		//SetValueToPublic_Var ();
		//TestMove ();
		KeyInput ();
	}

	void FixedUpdate()
	{
		TestMove ();
	}

	void KeyInput()
	{
		if (Input.GetKey (KeyCode.W)) 
						W = true;
				else
						W = false;
		if(Input.GetKey(KeyCode.A))
			A=true;
		   else A=false;
		if(Input.GetKey(KeyCode.D))
			D=true;
		else D=false;
		if(Input.GetKey(KeyCode.Space))
			SPACE=true;
		else SPACE=false;
		if(Input.GetKey(KeyCode.LeftShift))
			L_SHIFT=true;
		else L_SHIFT=false;

	}

	void SetValueToPublic_Var()
	{
		SetValueCounter_CountUp ();
		int a = SetValueCounter % 10;
		GameObject Value = GameObject.Find ("Public_Value");
		Public_Value Value_Script = Value.GetComponent<Public_Value> ();
		Value_Script.Bulldozer_Pos [a] = transform.FindChild("CameraPoint").transform.position;
		Value_Script.Bulldozer_Angle [a] = transform.FindChild("CameraPoint").transform.rotation;
	}

	void SetValueCounter_CountUp()
	{
		SetValueCounter++;
		if (SetValueCounter == 10)
						SetValueCounter = 0;
		Camera_MovingCounter++;
		if (Camera_MovingCounter == 10)
						Camera_MovingCounter = 0;
	}

	void SetValueToPublic_Value_First()
	{
		GameObject Value = GameObject.Find ("Public_Value");
		Public_Value Value_Script = Value.GetComponent<Public_Value> ();
		for (int a=0; a<10; a++) {
			Value_Script.Bulldozer_Pos [a] = transform.FindChild("CameraPoint").transform.position;
			Value_Script.Bulldozer_Angle [a] = transform.FindChild("CameraPoint").transform.rotation;
				}
	}
	void TestMove()
	{
		if (W==true&&SPACE==false) {
			if(Torque_Wheel<100)
			Torque_Wheel+=0.5f;
			this.rigidbody.AddForce(this.transform.rotation*new Vector3(0,0,Torque_Wheel),ForceMode.Acceleration);
				}
		else  {
			if(Torque_Wheel>0)
			Torque_Wheel-=0.5f;
			this.rigidbody.AddForce(this.transform.rotation*new Vector3(0,0,Torque_Wheel),ForceMode.Acceleration);
				}

		if (SPACE==true) {
			if(BackPower<30)
				BackPower++;
			this.rigidbody.AddForce(this.transform.rotation*new Vector3(0,0,BackPower)*-1,ForceMode.Acceleration);
						GameObject Light1 = GameObject.Find ("Bulldozer/RightBrakeLight");
						GameObject Light2 = GameObject.Find ("Bulldozer/LeftBrakeLight");
						Light1.light.intensity = 0.8f;
						Light2.light.intensity = 0.8f;
				} else {
			if(BackPower<0)
				BackPower--;
			GameObject Light1 = GameObject.Find ("Bulldozer/RightBrakeLight");
			GameObject Light2 = GameObject.Find ("Bulldozer/LeftBrakeLight");
			Light1.light.intensity = 0;
			Light2.light.intensity = 0;
				}

		if (Input.GetKey (KeyCode.LeftShift)) {
						if (D==true) {
								this.rigidbody.AddTorque (new Vector3 (0, 30, 0), ForceMode.Acceleration);
						}
						else if (A==true) {
								this.rigidbody.AddTorque (new Vector3 (0, -30, 0), ForceMode.Acceleration);
						}
				}
		else
		{
			if (D==true) {
				if(Torque_Wheel>40)
					Torque_Wheel-=2;
				this.rigidbody.AddTorque (new Vector3 (0, 10000000, 0), ForceMode.Force);
			}
			else if (A==true) {
				if(Torque_Wheel>40)
					Torque_Wheel-=2;
				this.rigidbody.AddTorque (new Vector3 (0, -10000000, 0), ForceMode.Force);
			}
		}
	}
}
