using UnityEngine;
using System.Collections;

public class PongFiftySpawner : MonoBehaviour {

	public GameObject fiveSpritePrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InstantiateFive(){
		Instantiate(fiveSpritePrefab, transform.position, Quaternion.identity);
	}
}
