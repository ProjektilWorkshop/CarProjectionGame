using UnityEngine;
using System.Collections;

public class WheelScript : MonoBehaviour {

	public float speedX = -600;
	public float speedY = 0;
	public float speedZ = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Time.deltaTime*speedX,Time.deltaTime*speedY,Time.deltaTime*speedZ);
	}
}
