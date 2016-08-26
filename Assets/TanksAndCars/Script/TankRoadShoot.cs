using UnityEngine;
using System.Collections;

public class TankRoadShoot : MonoBehaviour {

	float speed = 0.1f;

	public void SetSpeedX( float speedx ) {
		Debug.Log("TankRoadShoot.SetSpeed:"+speedx);
		speed = speedx;
	}

	public TanksAndCars gameLogic;

	// Use this for initialization
	void Start () {
		// speed = 0.35f; // similar to .. 
		// relativez = -2.7f;
		// transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameLogic.levelz+relativez);
			
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(new Vector3(0.0f,0.0f,speed), Space.World);
		transform.Translate(new Vector3(0.12f,0.0f,0.0f), Space.World);
			// faster now ...
		if (transform.position.x>1.0f) {
			Destroy(this.gameObject);
		}
	}
}
