using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Kanone : MonoBehaviour 
{
	public float minimum = 270f;
	public float maximum = 325f;
	public bool bewegen;
	private float zeit;
	public float aufladezeit;
	public float aufladegeschwindigkeit;
	public float maxaufladezeit;


	public int aktuellerStatus;

	public GameObject kanone; 
	public GameObject prefab; 
	public Schussprojetor schussprojector;
	public Torpedo torpedo;
	public GameObject explosionprefab;
	public Projector strich;
	public GameObject Aufladeansicht;
	public GameObject Aufladebalken;




	// Use this for initialization
	void Start ()
	{

		bewegen = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if (bewegen == true) 
		{
			zeit += Time.deltaTime;
			float t = Mathf.Sin (zeit);
			t = (t + 1) / 2;

			transform.eulerAngles = new Vector3(0, Mathf.Lerp(minimum, maximum, t), 0);
		}

		if (bewegen == false && Input.GetKeyDown ("space") && schussprojector.punktbewegen == false)
		{
			GameObject torpedo = Instantiate(prefab, kanone.transform.position, kanone.transform.rotation) as GameObject;
			torpedo.GetComponent<Torpedo> ().kanonescript = this;
			torpedo.GetComponent<Torpedo> ().schussprojector = schussprojector;
		}

		if (Input.GetKeyDown ("space")) 
		{
			bewegen = false;
		}
		*/

		// links rechts bewegung von Kanone

		if (Input.GetKeyDown ("r"))
			{
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
			}

		if (aktuellerStatus == 0)
		{
			zeit += Time.deltaTime;
			float t = Mathf.Sin (zeit);
			t = (t + 1) / 2;

			transform.eulerAngles = new Vector3(0, Mathf.Lerp(minimum, maximum, t), 0);

			if (Input.GetKeyDown ("space")) 
			{
				Aufladeansicht.SetActive (true);
				strich.enabled = false;
				aktuellerStatus = 1;


			}
		}

		//Kanone stoppt, lädt auf
		else if (aktuellerStatus == 1)
		{
			aufladezeit += Time.deltaTime;

			Aufladebalken.transform.localScale = new Vector3 ( Mathf.Lerp(0f, 1.2f, aufladezeit/maxaufladezeit), 1, 1);

			
				

			if (aufladezeit >= maxaufladezeit) 
			{
				aktuellerStatus = 2;
			}

			if (Input.GetKeyUp ("space"))
			{
				aktuellerStatus = 2;	
			}
			
		}

		//abschiessen
		else if (aktuellerStatus == 2)
		{
			GameObject torpedoGameObject = Instantiate(prefab, kanone.transform.position, kanone.transform.rotation) as GameObject;
			torpedo = torpedoGameObject.GetComponent<Torpedo> ();
			torpedo.kanonescript = this;
			torpedo.schussprojector = schussprojector;
			aufladezeit *= aufladegeschwindigkeit;
			Aufladeansicht.SetActive (false);

			aktuellerStatus = 3;
		}

		// Kanone stoppt/Torpedo zum Auto unterwegs
		else if (aktuellerStatus == 3)
		{
			aufladezeit -= Time.deltaTime;
			if (aufladezeit <= 0) 
			{
				Destroy (torpedo.gameObject);
				aktuellerStatus = 6;
			}
		}

		//Kanone stoppt/ Torpedo auf Auto unterwegs
		else if (aktuellerStatus == 4)
		{
			aufladezeit -= Time.deltaTime;
	
			if (aufladezeit <= 0) 
			{
				aktuellerStatus = 5;
			}

		}

		//Auto stoppt/Explosion auf Auto
		else if (aktuellerStatus == 5)
		{
			GameObject explosiongameobject = Instantiate(explosionprefab, Vector3.zero, Quaternion.identity) as GameObject;
			explosiongameobject.transform.position = new Vector3 (this.transform.position.x, schussprojector.transform.position.y, this.transform.position.z);
			explosiongameobject.transform.rotation = this.transform.rotation;
			aktuellerStatus = 6;
		}

		else if (aktuellerStatus == 6)
		{
			strich.enabled = true;
			aktuellerStatus = 0;
			aufladezeit = 0;
		}
	
	}
}
