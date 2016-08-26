using UnityEngine;
using System.Collections;

public class ProjectorMovement : MonoBehaviour {

	float speed = 8;
	public Transform otherProjector;
	Projector projector;
	Vector3 diff;
	public bool isFirst;

	// Use this for initialization
	void Start () {
		projector = GetComponent<Projector>();
		if(isFirst)
			diff = transform.position - otherProjector.position;
		else
			diff = otherProjector.position - transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += transform.up * Time.deltaTime * speed;
	
	}

	void OnTriggerExit(Collider inC){
		if(inC.name == "Ground"){
			//Debug.Log("ground leave");
			transform.position = otherProjector.position + diff;
			GetComponent<Projector>().enabled = false;
			otherProjector.GetComponent<Projector>().enabled = true;
		}
	}
}
