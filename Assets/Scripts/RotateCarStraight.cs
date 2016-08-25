using UnityEngine;
using System.Collections;

public class RotateCarStraight : MonoBehaviour {

	public LanesAndCars lanesAndCars;
	public TanksAndCars tanksAndCars;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float factor = 1.0f;

		bool doRotation = false;
		if (lanesAndCars!=null) {
			if (lanesAndCars.GetState().Equals("")) {
				doRotation = true;
			}
			if (lanesAndCars.DoubleEffects()) {
				factor = 2.0f;
			}
		}
		if (tanksAndCars!=null) {

		}
		if (doRotation) {
			float xRot = Mathf.Sin(Time.time * 20.0f ) * 1.0f * factor;
			float zRot = Mathf.Sin(Time.time * 5.0f ) * 2.0f * factor ;
			transform.localEulerAngles = new Vector3 ( xRot,90, zRot );
		}
	}
}
