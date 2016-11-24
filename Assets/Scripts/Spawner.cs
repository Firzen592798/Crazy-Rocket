using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject obstaculoPrefab;
	public GameObject foguete;
	private int _killer;
	private float _size = 0.5f;

	// Use this for initialization
	void Start () {
		Spawn ();
	}

	void Spawn() {
		GameObject obstaculo = GameObject.Instantiate (obstaculoPrefab) as GameObject;
		if (_killer == 3) {
			_killer = 0;
			obstaculo.transform.position = new Vector3(transform.position.x, foguete.transform.position.x);
		}else{
			obstaculo.transform.position = transform.position - (Random.Range(0f, 1f) * Vector3.up) - (Random.Range(-2f, 2f) * Vector3.left);
			_killer++;
		}
		obstaculo.transform.position = transform.position - (Random.Range (0f, 1f) * Vector3.up) - (Random.Range(-2f, 2f) * Vector3.left);

		float tamanho = Random.Range (0.5f, 2f);

		obstaculo.transform.localScale = new Vector3 (tamanho * _size, tamanho * _size, 1f);
		Invoke ("Spawn", Random.Range (1f, 2.5f));
	}

	// Update is called once per frame
	void Update () {

	}
}
