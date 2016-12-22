using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GUIText gameOverText;
	public GUIText scoreText;
	public bool restart;
	private int score;
	public int lives = 3;	
	private bool gameOver;
	private bool restartClick;
	public AudioClip explosao, colisao, impulso, item;
	FogueteController fogueteController;
	// Use this for initialization
	void Start () {
		GameObject fogueteObject = GameObject.FindWithTag ("Player");
		fogueteController = fogueteObject.GetComponent<FogueteController>();
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
		GetComponent<AudioSource>().PlayOneShot (explosao, 1.0f);

		fogueteController.explodir();
		restart = true;
		gameOverText.text = "Game Over. \nToque em qualquer lugar\n da tela para reiniciar";
		gameOver = true;
	}

	public void Ponto(){
		if (!restart) {
			score++;
			scoreText.text = "Score: " + score;
		}
	}
	public void Ponto(int pontos){
		if (!restart) {
			score += pontos;
			scoreText.text = "Score: " + score;
		}
	}

	public void SomColisao(){
		GetComponent<AudioSource>().PlayOneShot (colisao, 1.0f);
	}

	public void StopSound(){
		GetComponent<AudioSource> ().Stop ();
	}

	public void buffImpulso(){
		GetComponent<AudioSource>().PlayOneShot (item, 1.0f);
		fogueteController.buffImpulso ();
	}

	public void SomImpulso(){
		GetComponent<AudioSource>().PlayOneShot (impulso, 0.34f);
	}
}
