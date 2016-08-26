using UnityEngine;
using System.Collections;

public class StartMovieTexture : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MovieTexture mT = (MovieTexture)GetComponent<Renderer> ().material.mainTexture;
		mT.loop = true;
		mT.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
