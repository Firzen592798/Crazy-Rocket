using UnityEngine;
using System.Collections;

public class ObstaculoController : MonoBehaviour {

	public float speed;
	private GameController gameController;
	private Spawner spawner;
	private FogueteController fogueteController;
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		GameObject spawnerObject = GameObject.FindWithTag ("Spawner");
		GameObject fogueteObject = GameObject.FindWithTag ("Player");
		gameController = gameControllerObject.GetComponent<GameController> ();
		spawner = spawnerObject.GetComponent<Spawner> ();
		fogueteController = fogueteObject.GetComponent<FogueteController>();
		this.transform.GetComponent<Rigidbody2D> ().velocity = Vector2.down * speed + Vector2.left * Random.Range (-0.2f, 0.2f) * speed;
		//this.transform.GetComponent<Rigidbody2D> ().velocity.x = Random.Range(-1, 1) * speed;
	}

	// Update is called once per frame
	void Update () {
		/*if (this.transform.localScale.x >= spawner.size * 2.0) {
			spawner.PrepararDividir (this.gameObject);
		}*/
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
			if (fogueteController.lives == 0) {
				gameController.GameOver ();
			}
		}
	}

	void SpeedUp() {
		//speed *= 1.25f;
	}
}
