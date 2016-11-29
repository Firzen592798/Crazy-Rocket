using UnityEngine;
using System.Collections;

public class FogueteController : MonoBehaviour 
{
	
	public float moveSpeed = 40f;
	public float tempoImpulso = 1f;
	private float _nextImpulso = 0f;
	private bool _moving = false;
	private Vector3 _targetPos;

	private float impulsoAtual = 8;
	public float impulsoCheio = 10;
	public Texture contorno, barraImpulso;

	//----------------------------
	public TrocandoSprites _TrocandoSprites;
	//-----------------------------

	void OnGUI()
	{
		
		GUI.DrawTexture (new Rect (Screen.width / 27, Screen.height / 25, Screen.width / 8.5f/impulsoCheio*impulsoAtual, Screen.height / 35), barraImpulso);
		GUI.DrawTexture (new Rect (Screen.width / 30, Screen.height / 40, Screen.width / 8, Screen.height / 17), contorno);
	
	}


	//------
	float timeLeft = 2;
	//------
	// Update is called once per frame
	void Update () 
	{
		
		impulsoAtual = 10 * (1 - Mathf.Max(_nextImpulso - Time.time, 0));

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
					Debug.Log( "descendo" );


				}else if( _targetPos.y > transform.position.y )
				{

					_TrocandoSprites.Subindo();
					Debug.Log( "subindo" );

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

		timeLeft -= Time.deltaTime;
		if ( timeLeft < 0 )
		{
			_TrocandoSprites.Parado();
			timeLeft = 2;
		}

		//_TrocandoSprites.Parado();

	}

}