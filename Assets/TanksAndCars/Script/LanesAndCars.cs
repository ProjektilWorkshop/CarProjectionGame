using UnityEngine;
using System.Collections;


public class LanesAndCars: MonoBehaviour {

	bool addTree = true;

	string state = "start"; // intro||end
	public string GetState() {
		return state;
	}

	public GameObject break1;
	public GameObject break2;
	public WheelScript wheel1;
	public WheelScript wheel2;
	public TextMesh textObj;

	string gameTime = "";
	bool backupWrongTurn = false;

	public AudioSource audioSpeedOnCross;
	public AudioSource audioSpeedNormal;
	public AudioSource audioBreak;

	public GameObject backgroundPrefab; 
	public GameObject backgroundPrefabLeft; 
	public GameObject backgroundPrefabRight; 
	public GameObject backgroundPrefabStart;
	public GameObject backgroundPrefabEnd; 

	public GameObject tree0;
	public GameObject tree1;
	public GameObject tree2;

	public GameObject particlesGO;


	int[] arrLevel = {0,0,0,4,4,4,0,0,1,0,1,2,0,0,1,0,0,0,1,0,0,0,1,0,2,0,1,0,0,1,1,1,1,2,2,2,2,0,0,2,1,1,1,0,2,1,2,1,3,0};

	public GameObject level;
	public GameObject ground;

	float offset = 0.15f;
	float[] arrLane = { 0.0f, 1.8f }; 

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
			if (el==3) {
				obj = (GameObject) Instantiate( backgroundPrefabEnd, new Vector3(0.0f,0.0f,posz), new Quaternion());
			}
			if (el==4) {
				obj = (GameObject) Instantiate( backgroundPrefabStart, new Vector3(0.0f,0.0f,posz), new Quaternion());
			}
			if (obj!=null) {
				obj.transform.parent = ground.transform;
			}
			// add trees
			if (addTree)
			if (UnityEngine.Random.Range(0,3)==0) {
				int amount = UnityEngine.Random.Range(0,4);
				for (int a=0;a<amount;a++) {
					int which = UnityEngine.Random.Range(0,3);
					float wherex = Random.Range(6.0f,10.0f);
					float wherey = 7.2f+2;
					float wherez = posz + Random.Range(-4.0f,-8.0f);
					GameObject objx = null;
					if (which==0) {
						objx = (GameObject) Instantiate( tree0, new Vector3(wherex,wherey,wherez), tree0.transform.rotation);
					}
					if (which==1) {
						objx = (GameObject) Instantiate( tree1, new Vector3(wherex,wherey,wherez), tree1.transform.rotation);
					}
					if (which==2) {
						objx = (GameObject) Instantiate( tree2, new Vector3(wherex,wherey,wherez), tree2.transform.rotation);
					}
					if (objx!=null) {
						objx.transform.parent = ground.transform;
					}
				}
			}
			posz = posz + depth;
		}


		SetState("start");
	}
	
	// Update is called once per frame
	float speedo = 0.0f; // actual speed
	float speedSpeed = 0.03f; // 

	float speed = -0.07f;
	float speedExtended = -0.2f;
	int actualLaneLevel = 0;
	int actualLane = 0;
	float changeLaneSpeed = 0.3f;
	float actSpeedX = 0.0f;

	float levelz = 0.0f;
	float depth = 6.0f;
	int actualTile = 0;

	int actJob = 0;

	float time = 0.0f;

	void SetState( string newstate ) {
		Debug.Log("LanesAndCars.SetState("+newstate+")");
		state = newstate;
		if (newstate.Equals("start")) {
			time = Time.time;
			levelz = -6.0f * 5.0f;
			SetMessage("START");
			wheel1.enabled = false;
			wheel2.enabled = false;
			SetCarPosition(levelz);
			audioSpeedOnCross.Stop();
			audioSpeedNormal.Stop();
		}
		if (newstate.Equals("")) {
			StartGame();
		}
		if (newstate.Equals("stop")) {
			wheel1.enabled = false;
			wheel2.enabled = false;
			audioSpeedOnCross.Stop();	
			audioSpeedNormal.Stop();
		}
	}

	void StartGame() {
		levelz = -6.0f*5.0f;
		SetCarPosition( levelz );
		time = Time.time;
		// speedtoGo = speed;
		state = "";
		actualTile = 0;
		wheel1.enabled = true;
		wheel2.enabled = true;
		audioSpeedOnCross.Stop();
		audioSpeedNormal.Play();

	}

	void FixedUpdate () {
		// Debug.Log("LanesAndCars.FixedUpdate() // state = "+state);



		// ingame
		if (state.Equals("")) {

			wrongTurn = false;

			gameTime = ""+((int) ((Time.time-time)*10))/10.0f;
			SetMessage(""+gameTime+" SEC");

			actJob = arrLevel[-actualTile];
			if (actJob==3) {
				// end
				// levelz = 0.0f;
				// time = Time.time;
				SetState("stop");
				return;
			} 

			float speedtoGo = 0.0f;
			if (actJob==0) {
				speedtoGo = speedExtended;
				Faster();
			}
			if (actJob==1) {
				if (actualLane==0) {
					speedtoGo = speed;
					BreakNow();
				} else {
					speedtoGo = speedExtended;
					Faster();
				}
			}
			if (actJob==2) {
				if (actualLane==1) {
					speedtoGo = speed;
					BreakNow();
				} else {
					// levelz = levelz - speedExtended;
					speedtoGo = speedExtended;
					Faster();
				}
			}
			if (actJob==4) {
				speedtoGo = speed;
			}
			if (actJob==3) {
				speedtoGo = speed;
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
			// ground.transform.position = new Vector3(0.0f+offset+actSpeedX,0.0f,levelz);
			SetCarPosition(levelz);
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
			// Debug.Log("new actualLane "+actualTile+" "+actJob+"-["+speedtoGo+"/"+speedo+"]-"+levelz);
			//}
			actualTile = iactualTile;

			// sound
			if (wrongTurn!=backupWrongTurn) {
				if (wrongTurn) {
					audioSpeedOnCross.Play();	
					audioSpeedNormal.Stop();
				}
				if (!wrongTurn) {
					audioSpeedOnCross.Stop();	
					audioSpeedNormal.Play();
				}
			}
			backupWrongTurn = wrongTurn;
		}
	}

	void SetCarPosition(float ilevelz) {
		ground.transform.position = new Vector3(0.0f+offset+actSpeedX,0.0f,ilevelz);
	}

	void BreakNow() {
		break1.SetActive(true);
		break2.SetActive(true);
		wrongTurn = true;
		particlesGO.SetActive (true);
	}
	void Faster() {
		break1.SetActive(false);
		break2.SetActive(false);
		particlesGO.SetActive (false);
	}

	bool wrongTurn = false;
	public bool DoubleEffects() {
		return wrongTurn;
	}

	void SetMessage( string msg ) {
		textObj.text = msg;
	}

	void Update() {
		if (Input.GetKeyDown("left")) {
			actualLane = 0	;	
			if (!state.Equals("")) {
				SetState("");
			}
		}
		if (Input.GetKeyDown("right")) {
			actualLane = 1	;	
			if (!state.Equals("")) {
				SetState("");
			}
		}


	}

	void OnGUI() {
		GUI.Label(new Rect(0,0,200,20),"TIME: "+(Time.time-time));
	}
}
