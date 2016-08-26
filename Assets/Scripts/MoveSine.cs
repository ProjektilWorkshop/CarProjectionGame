using UnityEngine;
using System.Collections;

public class MoveSine : MonoBehaviour {

	private Vector3 originalPosition;
	public float amplitude = 1.0f;
	public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		this.originalPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = this.originalPosition + (Vector3.up * Mathf.Sin (Time.time*this.speed) + Vector3.left * Mathf.Sin (10+Time.time*this.speed)) * this.amplitude;
	}
}
