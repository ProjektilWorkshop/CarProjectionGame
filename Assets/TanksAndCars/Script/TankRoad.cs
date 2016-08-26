using UnityEngine;
using System.Collections;

public class TankRoad : MonoBehaviour {

	float speed = 0.001f;
	float relativez = 0.0f;

	bool shot = false;

	public TanksAndCars gameLogic;

	public GameObject turm;

	// Use this for initialization
	void Start () {
		speed = 0.5f; // similar to .. 
		// relativez = -2.7f;
		// transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameLogic.levelz+relativez);
		// turm.transform.Rotate(0.0f,90.0f,0.0f)	;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (gameLogic!=null) {
			// speed = gameLogic.GetSpeedDo();
			// Debug.Log("TankRoad.FixedUpdate() // speed="+speed);
		}

		// gameLogic. levelz
		// relativez = relativez + speed;
		// gameObject.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameLogic.levelz+relativez);
		// gameObject.transform.Translate(0.0f,0.0f,speed);
		transform.Translate(new Vector3(0.0f,0.0f,speed), Space.World);
		if (!shot) {
		if (transform.position.z > 0.0f) {
			shot = true;
			// turm.transform.Rotate(0.0f,90.0f,0.0f)	;
			if (gameLogic!=null) {
				// speed = - gameLogic.GetSpeedDo();
				// Debug.Log("TankRoad.FixedUpdate() // speed="+speed);
					gameLogic.CreateShootAt(transform.position,- gameLogic.GetSpeedDo());
			}
			// speed = 0.0f;
//			speed = speed * 3.0f;
		}}
		if (shot) {
			// transform.Translate(new Vector3(0.1f,0.0f,0.0f)); // , Space.World);
			// faster now ...
			turm.transform.Rotate(0.0f,-10.0f,0.0f)	;
			if (transform.position.z<-7.0f) {
				Destroy(this.gameObject);
			}
			transform.Translate(new Vector3(-0.3f,0.0f,0.0f), Space.World);
		}
	}
}

// version 1.0
/*
 * public class TankRoad : MonoBehaviour {

	float speed = 0.001f;
	float relativez = 0.0f;

	bool shot = false;

	public TanksAndCars gameLogic;

	// Use this for initialization
	void Start () {
		speed = 0.35f; // similar to .. 
		// relativez = -2.7f;
		// transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameLogic.levelz+relativez);
			
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (gameLogic!=null) {
			// speed = gameLogic.GetSpeedDo();
			// Debug.Log("TankRoad.FixedUpdate() // speed="+speed);
		}

		// gameLogic. levelz
		// relativez = relativez + speed;
		// gameObject.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameLogic.levelz+relativez);
		// gameObject.transform.Translate(0.0f,0.0f,speed);
		transform.Translate(new Vector3(0.0f,0.0f,speed), Space.World);
		if (!shot) {
		if (transform.position.z > 0.0f) {
			shot = true;
			if (gameLogic!=null) {
				speed = - gameLogic.GetSpeedDo();
				// Debug.Log("TankRoad.FixedUpdate() // speed="+speed);

			}
			// speed = 0.0f;
		}}
		if (shot) {
			transform.Translate(new Vector3(0.1f,0.0f,0.0f)); // , Space.World);
			// faster now ...
		}
		if (transform.position.x>0.0f) {
			Destroy(this.gameObject);
		}
	}
}
*/
