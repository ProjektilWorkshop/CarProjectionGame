using UnityEngine;
using System.Collections;

public class PongReceiverMovement : MonoBehaviour {

	float speed;

	// Use this for initialization
	void Start () {
		speed = Random.Range(17f, 22f);
	}
	
	void FixedUpdate(){
		transform.position += new Vector3(1, 0, 0)*speed*Time.fixedDeltaTime;
		if(transform.position.x >= 7 || transform.position.x <= -7){
			speed = -speed;
		}
	}
}
