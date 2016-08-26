using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PongGameLogic : MonoBehaviour {

	public int score;
	public int i;
	public TextMesh scoreText;
	public TextMesh Highscore;
	public TextMesh TimerText;
	public TextMesh finishText;
	private float timeLeft = 30f;
	public static bool timeUp= false;

	// Use this for initialization
	void Start () {
		score = 0;
		i = 1;
	}
	
	// Update is called once per frame
	void Update () {

		if(timeLeft >0){
			timeLeft -= Time.deltaTime;
		}
		else {
			timeUp = true;
			if(PlayerPrefs.GetInt("Highscore") < score){
				PlayerPrefs.SetInt("Highscore", score);
			}
		}

		if(timeUp == false){
			TimerText.text = "" + System.Convert.ToInt32(timeLeft);
			Highscore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
			scoreText.text = "Score: " + score;
			finishText.text = "";
		}
		else if (timeUp == true){
			TimerText.text = "";
			Highscore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
			scoreText.text = "";
			finishText.text = "Your Score: " + score;
		}


		if(Input.GetKeyDown(KeyCode.R)){
			score = 0;
			i = 1;
			timeLeft = 30f;
			timeUp = false;
			GameObject gO = GameObject.Find("Projector_LoadCar");
			gO.transform.position = new Vector3(gO.transform.position.x, -1.8f, gO.transform.position.z);		
		}
	}

}
