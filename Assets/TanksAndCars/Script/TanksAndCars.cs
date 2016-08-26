using UnityEngine;
using System.Collections;


public class TanksAndCars: MonoBehaviour {

	int levelDifficulty = 0; // level to go ...
	int score = 0;

	public GameObject hitbox;

	public TextMesh textObj;

	public GameObject enemyTank;
	public GameObject enemyTankShoot;

	public AudioSource audioAcc;
	public AudioSource audioBreak;

	public GameObject break1;
	public GameObject break2;
	 
	public GameObject backgroundPrefab; 
	public GameObject backgroundPrefabLeft; 
	public GameObject backgroundPrefabRight; 
	int[] arrLevel = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,0,0};

	public GameObject level;
	public GameObject ground;
	public GameObject enemies;

	float offset = 1.15f; // 0.05f;
	float[] arrLane = { 0.0f, 1.8f };

	float timeTimerNextEnemy = 0.0f;
	float timeIntervalNextEnemy = 3.0f;

	// Use this for initialization
	void Start () {

		if (hitbox!=null) {
			hitbox.SetActive(true);
		}

		// time for an enemy?
		if (Time.time>timeTimerNextEnemy) {
			Debug.Log("NewEnemy");
			timeTimerNextEnemy = Time.time + timeIntervalNextEnemy;
			// create one! now ...
			GameObject obj = null;
			// if (el==0) {
			obj = (GameObject) Instantiate( enemyTank, new Vector3(0.0f,0.0f,0.0f), new Quaternion());
			//}
			if (obj!=null) {
				obj.transform.parent = enemies.transform;
			}

			
		}

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
				obj = (GameObject) Instantiate( backgroundPrefab, new Vector3(0.0f,0.0f,posz), new Quaternion());
			}
			// backgroundPrefabRight
			if (obj!=null) {
				obj.transform.parent = ground.transform;
			}
			posz = posz +depth;
		}

		levelz = -6.0f * 5.0f;
//		state = "intro";

		// StartGame();
		actualTile = -5;


		StartGame();
	}
	
	// Update is called once per frame
	float speedo = 0.0f; // actual speed
	public float GetSpeedDo() {
		return speedo;
	}
	float speedSpeed = 0.005f; // adapt in tankroad !!!
	float speedSpeedBreak = 0.015f; 

	float speed = -0.1f;
	float speedExtended = -0.4f;
	int actualLaneLevel = 0;
	int actualLane = 0;
	float changeLaneSpeed = 0.3f;
	float actSpeedX = 0.0f;

	public float levelz = 0.0f;
	float depth = 6.0f;
	int actualTile = 0;

	int actJob = 0;

	float time = 0.0f;

	float speedtoGo = 0.0f;

	float timeToRelease = 0.0f;
	float timeToReleaseInterval = 1.0f;

	int doneTiles = 0;
	int lifes = 0;

	void StartGame() {
		doneTiles = 0;
	}

	void FixedUpdate () {
		 
		// Debug.Log("TanksAndCars.FixedUpdate() // actualTile: "+actualTile);

		// Debug.Log("TanksAndCars.FixedUpdate() // levelz: "+levelz);

		SetMessage(""+(doneTiles*3) +"m L:"+lifes+" D:"+levelDifficulty);

		// ...
		if (Time.time>timeToRelease) {
			timeToRelease = Time.time + timeToReleaseInterval;

			float posz = levelz;
			if (UnityEngine.Random.Range(0,2)==0) {
				GameObject obj;
				obj = (GameObject) Instantiate( enemyTank, new Vector3(-3.0f-Random.Range(0.0f,4.0f),0.0f,-10.0f-Random.Range(0.0f,4.0f)), new Quaternion());
				if (obj!=null) {
					obj.transform.parent = enemies.transform;
					TankRoad tr = obj.GetComponent<TankRoad>();
					if (tr!=null) {
						tr.gameLogic = this;
					}
				}
			}

		}

		// return; 

		// wrongTurn = false;
		if (((-actualTile)>=0)&&(-actualTile<arrLevel.Length)) {
			actJob = arrLevel[-actualTile];
			if (actJob==3) {
				// end
				levelz = 0.0f; // - 6.0f * 5.0f; // 5.0
				time = Time.time;
			}
		}



		// on change!
		/*
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
		*/

		// update speed
		// Debug.Log("TanksAndCars.FixedUpdate() // speedo["+speedo+"] speedtoGo["+speedtoGo+"]");
		if (speedo>speedtoGo) {
			speedo = speedo - speedSpeedBreak;
		}
		if (speedo<speedtoGo) {
			speedo = speedo + speedSpeed;
		}

		levelz = levelz + speedo;


		float actpos = (float) arrLane[actualLane];
		if (actpos<actSpeedX) actSpeedX = actSpeedX - changeLaneSpeed;
		if (actpos>actSpeedX) actSpeedX = actSpeedX + changeLaneSpeed;
		ground.transform.position = new Vector3(0.0f+offset+actSpeedX,0.0f,levelz);
		int iactualTile =(int)((levelz/*-depth*/)/depth);
		// next level
		/*
		if (((-actualTile)+1)>arrLevel.Length) {
			levelz = 0.0f;
			time = Time.time;
		}
		*/
		if (actualTile!=iactualTile) {
		// Debug.Log("new actualLane "+actualTile+" "+actJob+"-["+speedtoGo+"/"+speedo+"]-"+levelz);
			if (arrLevel[-actualTile]==1) {
				speedtoGo = speed;
			}
			doneTiles++;
		}
		actualTile = iactualTile;
	}

	public void CreateShootAt( Vector3 position, float speedx ) {
		Debug.Log("CreateShootAt("+speedx+")");
		GameObject obj;
		obj = (GameObject) Instantiate( enemyTankShoot, new Vector3(position.x,position.y,position.z), new Quaternion());
		if (obj!=null) {
			obj.transform.parent = enemies.transform;
			TankRoadShoot trx = obj.GetComponent<TankRoadShoot>();
			if (trx!=null) {
				Debug.Log("CreateShootAt("+speedx+").SetSpeed");
				trx.gameLogic = this;
				trx.SetSpeedX(speedx);
			} else {
				Debug.Log("CreateShootAt("+speedx+") TankRoadShoot not found!");
			}
		}


	}

	void SetMessage( string msg ) {
		textObj.text = msg;
	}

	// 		

	void Update() {
		if (Input.GetKeyDown("left")) {
			// actualLane = 0	;	
			speedtoGo = speedExtended;
			audioAcc.Play();
			audioBreak.Stop();
			break1.SetActive(false);
			break2.SetActive(false);
		}
		if (Input.GetKeyDown("right")) {
			// actualLane = 1	;
			speedtoGo = speed;
			audioAcc.Stop();
			audioBreak.Play();
			break1.SetActive(true);
			break2.SetActive(true);
		}

	}

	void OnGUI() {
		GUI.Label(new Rect(0,0,200,20),"TIME: "+(Time.time-time));
	}
}
