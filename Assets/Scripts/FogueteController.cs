using UnityEngine;
using System.Collections;

public class FogueteController : MonoBehaviour {
	public float moveSpeed = 40f;
	public float tempoImpulso = 1f;
	private float _nextImpulso = 0f;
	private bool _moving = false;
	private Vector3 _targetPos;

	public float vida;
	public float vidaCheia;
	public Texture contorno;

	void OnGui(){
		GUI.DrawTexture (new Rect (Screen.width / 40, Screen.height / 40, Screen.width / 5, Screen.height / 8), contorno);
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButton(0)) {
			if (Time.time > _nextImpulso) {
				_targetPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				_targetPos.z = transform.position.z;
				transform.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
				print (moveSpeed);
				transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(_targetPos.x - transform.position.x, _targetPos.y - transform.position.y) * moveSpeed);
				_nextImpulso = Time.time + tempoImpulso;
				//transform.position = Vector3.MoveTowards (transform.position, _targetPos, moveSpeed * Time.deltaTime);

			}
		}
	}




}
