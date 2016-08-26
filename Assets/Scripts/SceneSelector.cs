using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour {

	private Dictionary<KeyCode,string> keyToSceneDictionary;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		this.keyToSceneDictionary = new Dictionary<KeyCode, string>();

		// Add KeyCode and Scene Name
		this.keyToSceneDictionary.Add (KeyCode.Alpha1 , "IdleModeScene" );
		this.keyToSceneDictionary.Add (KeyCode.Alpha2 , "Pong" );
		this.keyToSceneDictionary.Add (KeyCode.Alpha3 , "LanesAndTanks" );
		this.keyToSceneDictionary.Add (KeyCode.Alpha4 , "CarScene" );
		this.keyToSceneDictionary.Add (KeyCode.Alpha5 , "LanesAndCars" );

		// Pseudo singleton. Destroy all SceneSelector Game Object except one
		GameObject[] gos = GameObject.FindGameObjectsWithTag("SceneSelector");
		for( int i = 0; i < gos.Length - 1; i++ ){
			Destroy (gos [i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach( KeyValuePair<KeyCode,string> kvp in this.keyToSceneDictionary ){
			if( Input.GetKeyDown( kvp.Key ) ){
				SceneManager.LoadScene ( kvp.Value );
			}
		}
	}
}
