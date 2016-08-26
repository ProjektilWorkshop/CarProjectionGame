using UnityEngine;
using System.Collections;

public class PongRotation_Object : MonoBehaviour {

	private float rotationSpeed;

	// Use this for initialization
	void Start () {
		rotationSpeed = 100;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate(Vector3.up * Time.fixedDeltaTime * rotationSpeed);

	}
}
