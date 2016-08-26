using UnityEngine;
using System.Collections;

public class CustomProjectorTextureAnimation : MonoBehaviour {

	public string folderName;
	public float speed = 1.0f;
	private Texture2D[] textures;
	private Projector projector;

	// Use this for initialization
	void Start () {
		this.textures = Resources.LoadAll <Texture2D> (this.folderName);
		this.projector = GetComponent<Projector> ();
		Debug.Log ("Loaded from "+this.ToString()+": "+this.textures.Length+" textures");
	}

	// Update is called once per frame
	void Update () {
		//this.projector.material.mainTexture = this.textures [ (int) Mathf.Floor(Time.time * this.speed) % this.textures.Length ];
		this.projector.material.SetTexture("_ShadowTex", this.textures [ (int) Mathf.Floor(Time.time * this.speed) % this.textures.Length ]);
	}
}
