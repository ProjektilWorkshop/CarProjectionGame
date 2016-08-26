using UnityEngine;
using System.Collections;

public class VisitorScript : MonoBehaviour {

	float speed = 2f;
	public TextMesh distanceText;

	public GameObject ZebraProjektorGO;
	bool isInTrigger;
	float triggerDist = 0;

	public Transform loadProjectorGOT;

	// Use this for initialization
	void Start () {
	
	}

	void Update(){
		distanceText.text = "Distance: "+(GetDist())+"m";
		if (isInTrigger) {
			float y = Mathf.Abs( GetDist () - triggerDist );
			//Debug.Log ("y: " + y);
			ZebraProjektorGO.GetComponent<Projector>().orthographicSize = 6.82f - y*4f;
			if (ZebraProjektorGO.GetComponent<Projector> ().orthographicSize < 0)
				ZebraProjektorGO.SetActive (false);
			else
				ZebraProjektorGO.SetActive (true);
			y = -3.22f + y;
			loadProjectorGOT.position = new Vector3 (loadProjectorGOT.position.x, y, loadProjectorGOT.position.z);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position += transform.forward * Input.GetAxis ("Vertical") * Time.deltaTime * speed;



	}

	float GetDist(){
		return transform.position.z - 6;
	}

	void OnTriggerEnter(Collider inC){
		if (inC.name == "NearTrigger") {
			Debug.Log("in trigger");
			//ZebraProjektorGO.SetActive (false);
			loadProjectorGOT.gameObject.SetActive (true);
			isInTrigger = true;
			triggerDist = GetDist ();
		}
	}
	void OnTriggerExit(Collider inC){
		if (inC.name == "NearTrigger") {
			Debug.Log("out trigger");
			//ZebraProjektorGO.SetActive (true);
			loadProjectorGOT.gameObject.SetActive (false);
			isInTrigger = false;
		}
	}
}
