using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject obstaculoPrefab;
	public GameObject impulsoPrefab;
	public GameObject foguete;
	private int _killer;
	private float time = 0;
	public float size = 0.1f;
	public float spawnRate = 1;
	// Use this for initialization
	void Start () {
		Spawn ();
		SpawnPowerup ();
		Invoke ("IncreaseSpawnRate", 5.0f);
	}

	void Spawn() {
		GameObject obstaculo = GameObject.Instantiate (obstaculoPrefab) as GameObject;
		obstaculo.transform.position = transform.position - (Random.Range(-1.0f, 0.0f) * Vector3.up) - (Random.Range(-2f, 2f) * Vector3.left);

		float tamanho = Random.Range (0.5f, 3.0f);

		obstaculo.transform.localScale = new Vector3 (tamanho * size, tamanho * size, 1f);
		Invoke ("Spawn", Random.Range (0.8f/spawnRate, 1.3f/spawnRate));
	}

	void SpawnPowerup() {
		GameObject impulso = GameObject.Instantiate (impulsoPrefab) as GameObject;
		impulso.transform.position = transform.position - (Random.Range(-1.0f, 0.0f) * Vector3.up) - (Random.Range(-2f, 2f) * Vector3.left);
		impulso.transform.localScale = new Vector3 (size * 2f, size * 2f, 1f);
		Invoke ("SpawnPowerup", Random.Range (5f, 10f));
	}

	void IncreaseSpawnRate(){
		spawnRate += 0.1f;
	}

	// Update is called once per frame
	void Update () {
		
	}


}
