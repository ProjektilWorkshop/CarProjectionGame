using UnityEngine;
using System.Collections;

public class PongBallSpawn : MonoBehaviour {

	float spawnFrequence = 1f;
	float lastSpawntime = 0;
	public GameObject BallPrefab;
	float speed;

	// Use this for initialization
	void Start () {
		speed = Random.Range(18f, 21f);
		spawnFrequence *= Random.Range(0.9f, 1.2f);
	}
	
	// Update is called once per frame
	void Update () {
		if( lastSpawntime + spawnFrequence < Time.time && PongGameLogic.timeUp == false){
			//Debug.Log("spawn: "+Time.time);//spawn;
			Instantiate(BallPrefab, transform.position, Quaternion.identity);
			lastSpawntime = Time.time;
		}
	}

	void FixedUpdate(){

		transform.position += new Vector3(1, 0, 0)*speed*Time.fixedDeltaTime;
		if(transform.position.x >= 7 || transform.position.x <= -7){
			speed = -speed;
		}

	}
}
