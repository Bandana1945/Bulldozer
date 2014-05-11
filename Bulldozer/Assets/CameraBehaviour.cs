using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {
	public GameObject Value;
	public Public_Value Value_Script;
	public GameObject Camera_P;
	public GameObject Bulldozer;
	Vector3 CameraRotation=new Vector3();
	float camSpeed =10.0f;
	// Use this for initialization
	void Start () {
		Value = GameObject.Find ("Public_Value");
		Value_Script = Value.GetComponent<Public_Value> ();
		Camera_P=GameObject.Find("Bulldozer/CameraPoint");
		Bulldozer = GameObject.Find ("Bulldozer");
	}
	
	// Update is called once per frame
	void Update() {
		Camera_Move ();
		MyLookUp ();
	}
	void Camera_Move()
	{
		transform.position=Vector3.Lerp(transform.position,Camera_P.transform.position,camSpeed*Time.deltaTime);
	}
	void MyLookUp()
	{
		transform.rotation = Quaternion.Slerp(this.transform.rotation, Bulldozer.transform.rotation, 10.0f*Time.deltaTime);
	}
}
