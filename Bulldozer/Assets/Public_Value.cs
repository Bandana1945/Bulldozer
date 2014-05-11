using UnityEngine;
using System.Collections;

public class Public_Value : MonoBehaviour {
	public Vector3[] Bulldozer_Pos=new Vector3[10];
	public Quaternion[] Bulldozer_Angle=new Quaternion[10];
	public int CameraMoveCounter=1;
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(this);
		for(int i=0;i<10;i++)
		{
			Bulldozer_Pos[i]=new Vector3();
			Bulldozer_Angle[i]=new Quaternion();
		}
	}
	
	// Update is called once per frame
	void Update () {
		CameraMoveCounter_CountUp ();
	}
	void CameraMoveCounter_CountUp()
	{
		CameraMoveCounter++;
		if (CameraMoveCounter == 10)
						CameraMoveCounter = 0;
	}
}
