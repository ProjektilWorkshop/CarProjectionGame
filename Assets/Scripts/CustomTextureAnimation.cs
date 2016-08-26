using UnityEngine;
using System.Collections;

public class CustomTextureAnimation : MonoBehaviour {

	public string folderName;
	public float speed = 1.0f;
	private Texture2D[] textures;
	private Renderer renderer;

	// Use this for initialization
	void Start () {
		this.textures = Resources.LoadAll <Texture2D> (this.folderName);
		this.renderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.renderer.sharedMaterial.mainTexture = this.textures [ (int) Mathf.Floor(Time.time * this.speed) % this.textures.Length ];
	}
}
