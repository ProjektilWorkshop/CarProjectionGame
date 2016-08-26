using UnityEngine;
using System.Collections;

public class Torpedo : MonoBehaviour {

	public float torpedospeed;
	public Kanone kanonescript;
	public Schussprojetor schussprojector;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate (0.0f,0.0f,-torpedospeed * Time.deltaTime);
	}

	void OnCollisionEnter (Collision collision)
	{
		Destroy (gameObject);
		kanonescript.aktuellerStatus = 4;


		/*foreach (ContactPoint contact in collision.contacts) 
		{
			Debug.DrawRay (contact.point, contact.normal, Color.red);
		}
		*/

	}
}
