using UnityEngine;
using System.Collections;

public class VisitorScript : MonoBehaviour {

	float speed = 4;
	public TextMesh distanceText;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += transform.forward * Input.GetAxis ("Vertical") * Time.deltaTime * speed;
		distanceText.text = "Distance: "+(transform.position.z-6)+"m";
	}

	void OnTriggerEnter(Collider inC){
		if (inC.name == "NearTrigger") {
			Debug.Log("in trigger");
		}
	}
	void OnTriggerExit(Collider inC){
		if (inC.name == "NearTrigger") {
			Debug.Log("out trigger");
		}
	}
}
