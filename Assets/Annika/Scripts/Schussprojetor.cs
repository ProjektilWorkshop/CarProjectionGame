using UnityEngine;
using System.Collections;

public class Schussprojetor : MonoBehaviour 
{

	public float projectorspeed;
	public Kanone kanone;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame

	void Update ()
	{
		if (kanone.aktuellerStatus == 4) {
			transform.Translate (0.0f, projectorspeed * Time.deltaTime, 0.0f);

			if (transform.position.y > 0.875f) 
			{
				kanone.aktuellerStatus = 6;
			}
		} 

		if (kanone.aktuellerStatus == 6)
		{
			transform.localPosition = new Vector3 (2.9f, 0.017f, 0.09f);
		}
	
	}
}
