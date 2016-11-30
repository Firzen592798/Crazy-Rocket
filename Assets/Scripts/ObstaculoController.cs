using UnityEngine;
using System.Collections;

public class ObstaculoController : MonoBehaviour {
	public GameObject obstaculoPrefab;
	public float speed;
	private GameController gameController;
	private Spawner spawner;
	private FogueteController fogueteController;
	private float velocidadeX = 0.0f	;
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		GameObject spawnerObject = GameObject.FindWithTag ("Spawner");
		GameObject fogueteObject = GameObject.FindWithTag ("Player");
		gameController = gameControllerObject.GetComponent<GameController> ();
		spawner = spawnerObject.GetComponent<Spawner> ();
		fogueteController = fogueteObject.GetComponent<FogueteController>();
		if (velocidadeX == 0) {
			velocidadeX = Random.Range (-0.2f, 0.2f);
		}
		this.transform.GetComponent<Rigidbody2D> ().velocity = Vector2.down * speed + Vector2.left * velocidadeX * speed;
		//this.transform.GetComponent<Rigidbody2D> ().velocity.x = Random.Range(-1, 1) * speed;
	}

	// Update is called once per frame
	void Update () {
		if (this.transform.localScale.x >= spawner.size * 2.0) {
			Invoke ("Dividir", Random.Range (1.0f, 3.0f));
		}
		//this.transform.GetComponent<Rigidbody2D> ().velocity += Vector2.up * speed;
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Wall")) {
			gameController.Ponto();
			print ("LOL");
			Destroy (gameObject);
		}
		if (col.CompareTag ("Player")) {
			fogueteController.lives--;
			Destroy (gameObject);
			if (fogueteController.lives == 0) {
				gameController.GameOver ();
			}
		}
	}

	void SpeedUp() {
		//speed *= 1.25f;
	}
		
	void Dividir() {
		GameObject obstaculo = GameObject.Instantiate (obstaculoPrefab) as GameObject;
		GameObject obstaculo2 = GameObject.Instantiate (obstaculoPrefab) as GameObject;
		float velX = Random.Range (0.2f, 0.5f);

		obstaculo.transform.position = transform.position;
		float tamanho = Random.Range (0.4f, 0.6f) * transform.localScale.x;
		obstaculo.transform.localScale = new Vector3 (tamanho, tamanho, 1f);
		obstaculo.GetComponent<ObstaculoController> ().velocidadeX = velX;

		obstaculo2.transform.position = transform.position;
		//tamanho = Random.Range (0.5f, 1.5f);
		obstaculo2.transform.localScale = new Vector3 (tamanho, tamanho, 1f);
		obstaculo.GetComponent<ObstaculoController> ().velocidadeX = -velX;
		Destroy (gameObject);
	}
}
