using UnityEngine;
using System.Collections;


public class LanesAndCars: MonoBehaviour {

	public GameObject backgroundPrefab; 
	public GameObject backgroundPrefabLeft; 
	public GameObject backgroundPrefabRight; 
	int[] arrLevel = {0,0,0,0,0,0,0,0,1,0,1,2,0,0,1,0,0,0,1,2,0,0,1,0,0,1,1,1,1,2,2,2,2,0,0,2,1,1,1,0,0,0,0,0,0,0,0,0,0,3,0};

	public GameObject level;
	public GameObject ground;

	float offset = 0.2f;
	float[] arrLane = { 0.0f, 2.0f };

	// Use this for initialization
	void Start () {

		// create a level!
		// random
		float posz = 0.0f;
		for (int z=0;z<arrLevel.Length;z++) {
			int el = arrLevel[z];
			GameObject obj = null;
			if (el==0) {
				obj = (GameObject) Instantiate( backgroundPrefab, new Vector3(0.0f,0.0f,posz), new Quaternion());
			}
			if (el==1) {
				obj = (GameObject) Instantiate( backgroundPrefabRight , new Vector3(0.0f,0.0f,posz), new Quaternion());
			}
			if (el==2) {
				obj = (GameObject) Instantiate( backgroundPrefabLeft, new Vector3(0.0f,0.0f,posz), new Quaternion());
			}
			if (obj!=null) {
				obj.transform.parent = ground.transform;
			}
			posz = posz + depth;
		}

		time = Time.time;
	}
	
	// Update is called once per frame
	float speedo = 0.0f; // actual speed
	float speedSpeed = 0.03f; // 

	float speed = -0.1f;
	float speedExtended = -0.3f;
	int actualLaneLevel = 0;
	int actualLane = 0;
	float changeLaneSpeed = 0.3f;
	float actSpeedX = 0.0f;

	float levelz = 0.0f;
	float depth = 6.0f;
	int actualTile = 0;

	int actJob = 0;

	float time = 0.0f;

	void FixedUpdate () {

		actJob = arrLevel[-actualTile];
		if (actJob==3) {
			// end
			levelz = 0.0f;
			time = Time.time;
		}

		float speedtoGo = 0.0f;
		if (actJob==0) {
			speedtoGo = speedExtended;
		}
		if (actJob==1) {
			if (actualLane==0) {
				speedtoGo = speed;
			} else {
				speedtoGo = speedExtended;
			}
		}
		if (actJob==2) {
			if (actualLane==1) {
				speedtoGo = speed;
			} else {
				// levelz = levelz - speedExtended;
				speedtoGo = speedExtended;
			}
		}

		// update speed
		if (speedo>speedtoGo) {
			speedo = speedo - speedSpeed;
		}
		if (speedo<speedtoGo) {
			speedo = speedo + speedSpeed;
		}

		levelz = levelz + speedo;


		float actpos = (float) arrLane[actualLane];
		if (actpos<actSpeedX) actSpeedX = actSpeedX - changeLaneSpeed;
		if (actpos>actSpeedX) actSpeedX = actSpeedX + changeLaneSpeed;
		ground.transform.position = new Vector3(0.0f+offset+actSpeedX,0.0f,levelz);
		int iactualTile = (int)((levelz-depth)/depth);
		// int iactualTile = (int)((levelz)/depth);
		// next level
		/*
		if (((-actualTile)+1)>arrLevel.Length) {
			levelz = 0.0f;
			time = Time.time;
		}
		*/
		//if (actualTile!=iactualTile) {
		Debug.Log("new actualLane "+actualTile+" "+actJob+"-["+speedtoGo+"/"+speedo+"]-"+levelz);
		//}
		actualTile = iactualTile;
	}

	void Update() {
		if (Input.GetKeyDown("left")) {
			actualLane = 0	;		
		}
		if (Input.GetKeyDown("right")) {
			actualLane = 1	;		
		}

	}

	void OnGUI() {
		GUI.Label(new Rect(0,0,200,20),"TIME: "+(Time.time-time));
	}
}
