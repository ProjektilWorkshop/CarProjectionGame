using UnityEngine;
using System.Collections;

public class Wheels : MonoBehaviour {

	public int speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.left * Time.deltaTime* speed);
	}
}
