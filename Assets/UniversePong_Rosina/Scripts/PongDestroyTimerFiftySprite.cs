using UnityEngine;
using System.Collections;

public class PongDestroyTimerFiftySprite : MonoBehaviour {

	private float timeLeftTillOver = 0.5f;
	private bool timeOver = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.localScale += new Vector3(0.025f, 0, 0.025f);

		if(timeLeftTillOver >0){
			timeLeftTillOver -= Time.deltaTime;
		}
		else {
			timeOver = true;
			}

		if(timeOver == true){
			Destroy(gameObject);
		}
	}
}
