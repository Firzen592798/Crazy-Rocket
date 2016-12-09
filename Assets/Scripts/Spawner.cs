using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject obstaculoPrefab;
	public GameObject impulsoPrefab;
	public GameObject foguete;
	private int _killer;
	public float size = 0.1f;

	// Use this for initialization
	void Start () {
		Spawn ();
		SpawnPowerup ();
	}

	void Spawn() {
		GameObject obstaculo = GameObject.Instantiate (obstaculoPrefab) as GameObject;
		obstaculo.transform.position = transform.position - (Random.Range(-1.0f, 0.0f) * Vector3.up) - (Random.Range(-2f, 2f) * Vector3.left);

		float tamanho = Random.Range (0.5f, 2.5f);

		obstaculo.transform.localScale = new Vector3 (tamanho * size, tamanho * size, 1f);
		Invoke ("Spawn", Random.Range (1f, 2.5f));
	}

	void SpawnPowerup() {
		GameObject impulso = GameObject.Instantiate (impulsoPrefab) as GameObject;
		impulso.transform.position = transform.position - (Random.Range(-1.0f, 0.0f) * Vector3.up) - (Random.Range(-2f, 2f) * Vector3.left);
		impulso.transform.localScale = new Vector3 (size * 2f, size * 2f, 1f);
		Invoke ("SpawnPowerup", Random.Range (5f, 10f));
	}

	// Update is called once per frame
	void Update () {

	}


}
