using UnityEngine;
using System.Collections;

public class PongBallMovement : MonoBehaviour {

	private float speed= 4;
	private bool PlayerFirst = false;

	// Use this for initialization
	void Start () {
		transform.LookAt(GameObject.Find("Receiver").transform);
	}

	// Update is called once per frame
	void FixedUpdate () {
		transform.position += transform.forward*Time.fixedDeltaTime*speed;

		if(PongGameLogic.timeUp == true ){
			Destroy(gameObject);
		}

		if(transform.position.z >= 8){
			if(GameObject.Find("Projector_LoadCar").transform.position.y > -1.8 && PongGameLogic.timeUp == false){
				GameObject.Find("Projector_LoadCar").transform.position -= new Vector3(0, 0.1f, 0);
			}
			GameObject.Find("GameLogic").GetComponent<PongGameLogic>().i = 0;
			if(GameObject.Find("GameLogic").GetComponent<PongGameLogic>().score >= 2 && PongGameLogic.timeUp == false){
				GameObject.Find("GameLogic").GetComponent<PongGameLogic>().score -= 2;
			}
			Destroy(gameObject);

		}
	}

	void OnTriggerEnter(Collider inCol){

		if(inCol.name.Equals("Player")){
			PlayerFirst = true;
			transform.LookAt(GameObject.Find("Fiat500R").transform);
		}
		if(inCol.name.Equals("Fiat500R") && PlayerFirst == true){
			if(GameObject.Find("Projector_LoadCar").transform.position.y < 1.4 && PongGameLogic.timeUp == false){
				GameObject.Find("Projector_LoadCar").transform.position += new Vector3(0, 0.15f, 0);
				}
			if(GameObject.Find("GameLogic").GetComponent<PongGameLogic>().i < 5 && PongGameLogic.timeUp == false){
				GameObject.Find("GameLogic").GetComponent<PongGameLogic>().score += 10;
				GameObject.Find("GameLogic").GetComponent<PongGameLogic>().i += 1;
			}
			else if(GameObject.Find("GameLogic").GetComponent<PongGameLogic>().i == 5 && PongGameLogic.timeUp == false){
				GameObject.Find("GameLogic").GetComponent<PongGameLogic>().score += 50;
				GameObject.Find("GameLogic").GetComponent<PongGameLogic>().i = 1;
				GameObject.Find("fiftySpawner").GetComponent<PongFiftySpawner>().InstantiateFive();
			}
			Destroy(gameObject);
			}

	}
}
