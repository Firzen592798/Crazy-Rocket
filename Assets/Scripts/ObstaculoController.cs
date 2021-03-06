﻿using UnityEngine;
using System.Collections;

public class ObstaculoController : MonoBehaviour {
	public GameObject obstaculoPrefab;
	public float speed;
	private GameController gameController;
	private Spawner spawner;
	private float velocidadeX = 0.0f;
	public GameObject explosaoPrefab;
	private GameObject fogueteObject;

	// Use this for initialization
	void Start () {
		//audioSource = this.GetComponent<AudioSource> ();
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		GameObject spawnerObject = GameObject.FindWithTag ("Spawner");
		gameController = gameControllerObject.GetComponent<GameController> ();
		spawner = spawnerObject.GetComponent<Spawner> ();
		if (velocidadeX == 0) {
			velocidadeX = Random.Range (-0.2f, 0.2f);
		}
		this.transform.GetComponent<Rigidbody2D> ().velocity = Vector2.down * speed + Vector2.left * velocidadeX * speed;
		if (this.transform.localScale.x >= spawner.size * 1.5) {
			Invoke ("Dividir", Random.Range (1.0f, 4.5f));
		}
		//this.transform.GetComponent<Rigidbody2D> ().velocity.x = R	andom.Range(-1, 1) * speed;
	}

	// Update is called once per frame
	void Update () {		
		//this.transform.GetComponent<Rigidbody2D> ().velocity += Vector2.up * speed;
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Wall")) {
			gameController.Ponto();
			Destroy (gameObject);
		}
		if (col.CompareTag ("Player")) {
			gameController.lives--;
			if (gameController.lives == 0) {
				//GetComponent<AudioSource>().PlayOneShot (explosao, 1.0f);


				gameController.Invoke("GameOver", 0f);

				gameController.StopSound ();	
			} else {
				gameController.SomColisao();
				//GetComponent<AudioSource>().PlayOneShot (impacto, 1.0f);
			}
			Destroy (gameObject);
		}
	}
		
	void SpeedUp() {
		//speed *= 1.25f;
	}
		
	void Dividir() {
		GameObject obstaculo = GameObject.Instantiate (obstaculoPrefab) as GameObject;
		GameObject obstaculo2 = GameObject.Instantiate (obstaculoPrefab) as GameObject;
		float velX = Random.Range (0.4f, 0.6f);
		Destroy (gameObject);
		obstaculo.transform.position = transform.position;
		float tamanho = Random.Range (0.4f, 0.6f) * transform.localScale.x;
		obstaculo.transform.localScale = new Vector3 (tamanho, tamanho, 1f);
		obstaculo.GetComponent<ObstaculoController> ().velocidadeX = velX;

		obstaculo2.transform.position = transform.position;
		//tamanho = Random.Range (0.5f, 1.5f);
		obstaculo2.transform.localScale = new Vector3 (tamanho, tamanho, 1f);
		obstaculo2.GetComponent<ObstaculoController> ().velocidadeX = -velX;

	}
}
