using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GUIText gameOverText;
	public GUIText scoreText;
	public bool restart;
	private int score;
	private bool gameOver;
	private bool restartClick;
	// Use this for initialization
	void Start () {
		score = 0;
		gameOver = false;
		restart = false;
		restartClick = false;
		gameOverText.text = "";
		scoreText.text = "Score: 0";
	}
	
	// Update is called once per frame
	void Update () {
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R) || Input.GetMouseButtonDown(0)) {
				Application.LoadLevel (Application.loadedLevel);
				Time.timeScale = 1;
				restart = false;
				restartClick = false;
			}
		}
	}

	public void GameOver(){
		Time.timeScale = 0;
		restart = true;
		gameOverText.text = "Game Over. \nToque em qualquer lugar\n da tela para reiniciar";
		gameOver = true;
	}

	public void Ponto(){
		print ("Ponto : " + score);
		score++;
		scoreText.text = "Score: "+score;
	}

}
