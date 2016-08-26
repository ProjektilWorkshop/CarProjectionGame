using UnityEngine;
using System.Collections;

public class PongPlayerMovement : MonoBehaviour {

	private float speed = 6;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.RightArrow)){
			if(transform.position.x >= -8){
				transform.position += new Vector3 (-1, 0, 0)* Time.deltaTime* speed;
			}
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			if(transform.position.x <= 8){
				transform.position += new Vector3 (1, 0, 0)* Time.deltaTime* speed;
			}
		}
	}
}
