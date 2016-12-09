using UnityEngine;
using System.Collections;

public class FogueteController : MonoBehaviour 
{
	
	public float moveSpeed = 40f;
	public float tempoImpulso = 1f;
	public GameObject explosaoPrefab;
	private float _nextImpulso = 0f;
	private float _timeBuff;
	private bool _moving = false;
	private Vector3 _targetPos;
	//public int lives = 3;
	private float impulsoAtual = 8;
	private bool temBuffImpulso = false;
	public float impulsoCheio = 10;
	public Texture contorno, barraImpulso, life, barraImpulsoBuff;
	private GameController gameController;
	//----------------------------
	public TrocandoSprites _TrocandoSprites;
	//-----------------------------

	void OnGUI()
	{
		if (temBuffImpulso) {
			GUI.DrawTexture (new Rect (Screen.width / 27, Screen.height / 25, Screen.width / 8.5f / impulsoCheio * impulsoAtual, Screen.height / 35), barraImpulsoBuff);
		} else {
			GUI.DrawTexture (new Rect (Screen.width / 27, Screen.height / 25, Screen.width / 8.5f/impulsoCheio*impulsoAtual, Screen.height / 35), barraImpulso);
		}
		GUI.DrawTexture (new Rect (Screen.width / 30, Screen.height / 40, Screen.width / 8, Screen.height / 17), contorno);
		for (int i = 0; i < gameController.lives; i++) {
			GUI.DrawTexture (new Rect (Screen.width / 5 + (i * 60), Screen.height / 60, Screen.width / 8, Screen.height / 17), life);
		}
	}


	//------
	float timeLeft = 2;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent<GameController> ();
	}

	//------
	// Update is called once per frame
	void Update () 
	{
		
		impulsoAtual = 10/tempoImpulso * (tempoImpulso - Mathf.Max(_nextImpulso - Time.time, 0));

		if( Input.GetMouseButton(0) ) 
		{
			
			if (Time.time > _nextImpulso) 
			{
				
				_targetPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				_targetPos.z = transform.position.z;

				transform.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;

				if( _targetPos.y < transform.position.y )
				{

					_TrocandoSprites.Descendo();
					//Debug.Log( "descendo" );


				}else if( _targetPos.y > transform.position.y )
				{

					_TrocandoSprites.Subindo();
					//Debug.Log( "subindo" );

				}

				transform.GetComponent<Rigidbody2D>().AddForce(new Vector2( _targetPos.x - transform.position.x, _targetPos.y - transform.position.y) * moveSpeed);
				_nextImpulso = Time.time + tempoImpulso;

				//transform.position = Vector3.MoveTowards (transform.position, _targetPos, moveSpeed * Time.deltaTime);

			}
		
		}

		if( impulsoAtual >= impulsoCheio ) 
		{
			impulsoAtual = impulsoCheio;
		}else if (impulsoAtual <= 0) 
		{
			impulsoAtual = 0;

		}
		if (temBuffImpulso) {
			if (Time.time - _timeBuff > 6) {
				temBuffImpulso = false;
				tempoImpulso = 1.0f;
			}
		}
		timeLeft -= Time.deltaTime;
		if ( timeLeft < 0 )
		{
			_TrocandoSprites.Parado();
			timeLeft = 2;
		}

		//_TrocandoSprites.Parado();

	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("Wall")) {
			this.transform.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		}
	}

	public void explodir(){
		GameObject explosao = GameObject.Instantiate (explosaoPrefab) as GameObject;
		explosao.transform.position = transform.position;
		Destroy (gameObject);
		
	}

	public void buffImpulso(){
		temBuffImpulso = true;
		_timeBuff = Time.time; 
		tempoImpulso = 0.5f;
	}
}