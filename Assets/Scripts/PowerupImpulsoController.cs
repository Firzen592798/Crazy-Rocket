using UnityEngine;
using System.Collections;

public class PowerupImpulsoController : MonoBehaviour {
	public float speed;
	private GameController gameController;
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController> ();
		this.transform.GetComponent<Rigidbody2D> ().velocity = Vector2.down * speed;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Wall")) {
			Destroy (gameObject);
		}
		if (col.CompareTag ("Player")) {
			gameController.Ponto (10);
			gameController.buffImpulso ();
			Destroy (gameObject);
		}
	}

}
