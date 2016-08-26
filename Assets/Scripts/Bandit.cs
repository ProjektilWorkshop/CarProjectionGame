using UnityEngine;
using System.Collections;

public class Bandit : MonoBehaviour {

	private float speedBandit1;
	private float speedBandit2;
	private float speedBandit3;
	public GameObject Colour1;
	public GameObject Colour2;
	public GameObject Colour3;
	private int countDown;

	//private bool  KeyPressed = false;

	// Use this for initialization
	void Start () {
		speedBandit1 = Random.Range(100f, 400f);
		speedBandit2 = Random.Range(200f, 300f);
		speedBandit3 = Random.Range(200f, 500f);

		countDown = 3;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.B)){
			countDown += 1;
			if (countDown >= 4)
				countDown = 0;
		}
		if( countDown == 0){
			Colour1.transform.Rotate(Vector3.left * Time.deltaTime* speedBandit1);
			Colour2.transform.Rotate(Vector3.left * Time.deltaTime* speedBandit2);
			Colour3.transform.Rotate(Vector3.left * Time.deltaTime* speedBandit3);
		}

		if(countDown == 1){
			Colour2.transform.Rotate(Vector3.left * Time.deltaTime* speedBandit2);
			Colour3.transform.Rotate(Vector3.left * Time.deltaTime* speedBandit3);
		}

		if(countDown == 2){
			Colour3.transform.Rotate(Vector3.left * Time.deltaTime* speedBandit3);
		}

	}
}