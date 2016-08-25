using UnityEngine;
using System.Collections;

public class RotateCarStraight : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float xRot = Mathf.Sin(Time.time * 20.0f ) * 1.0f;
		float zRot = Mathf.Sin(Time.time * 5.0f ) * 2.0f;
		transform.localEulerAngles = new Vector3 ( xRot,90, zRot );
	}
}
