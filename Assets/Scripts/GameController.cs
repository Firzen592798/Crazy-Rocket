using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GUIText gameOverText;
	public GUIText scoreText;
	public GUIText restartText;
	private int score;
	private bool gameOver;
	private bool restart;
	// Use this for initialization
	void Start () {
		score = 0;
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		scoreText.text = "Score: 0";
	}
	
	// Update is called once per frame
	void Update () {
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
				Time.timeScale = 1;
			}
		}
	}

	public void GameOver(){
		Time.timeScale = 0;
		restartText.text = "Restart";
		restart = true;
		gameOverText.text = "Game Over";
		gameOver = true;

	}
}
