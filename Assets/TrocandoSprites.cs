using UnityEngine;
using System.Collections;

public class TrocandoSprites : MonoBehaviour {

	public Sprite spriteparado; 
	public Sprite spritesubindo; 
	public Sprite spritedescendo; 
	public Sprite spritefrentedescendo;
	public Sprite spritefrentesubindo;
	public Sprite spritetrasdescendo;
	public Sprite spritetrassubindo;
	public Sprite spritefreando;



	private SpriteRenderer spriteRenderer; 

	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
			spriteRenderer.sprite = spriteparado; // set the sprite to sprite1
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.UpArrow)) // If the space bar is pushed down
		{
			Subindo (); // call method to change sprite
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) // If the space bar is pushed down
		{
			Descendo (); // call method to change sprite
		}


		if (Input.GetKeyDown (KeyCode.Space)) // If the space bar is pushed down
		{
			Freando (); // call method to change sprite
		}
		if (Input.GetKeyDown (KeyCode.PageUp)) // If the space bar is pushed down
		{
			FrenteSubindo (); // call method to change sprite
		}
		if (Input.GetKeyDown (KeyCode.PageDown)) // If the space bar is pushed down
		{
			FrenteDescendo (); // call method to change sprite
		}
		if (Input.GetKeyDown (KeyCode.Home)) // If the space bar is pushed down
		{
			TrazSubindo (); // call method to change sprite
		}
		if (Input.GetKeyDown (KeyCode.End)) // If the space bar is pushed down
		{
			TrazDescendo (); // call method to change sprite
		}

	}

	public void Subindo ()
	{

		Debug.Log( "subindo ScriptTrocando" );
		//if (spriteRenderer.sprite == spriteparado) // if the spriteRenderer sprite = sprite1 then change to sprite2
		//{
			spriteRenderer.sprite = spritesubindo;
		//}
		//else
		//{
		//	spriteRenderer.sprite = spriteparado; // otherwise change it back to sprite1
		//}
	}

	public void Descendo ()
	{
		//if (spriteRenderer.sprite == spriteparado) // if the spriteRenderer sprite = sprite1 then change to sprite2
		//{
		Debug.Log( "descendo ScriptTrocando" );
			spriteRenderer.sprite = spritedescendo;
		//}
		//else
		//{
			//spriteRenderer.sprite = spriteparado; // otherwise change it back to sprite1
		//}
	}

	public void Parado ()
	{
		spriteRenderer.sprite = spriteparado; // otherwise change it back to sprite1
		
	}

	public void Freando ()
	{
		spriteRenderer.sprite = spritefreando; // otherwise change it back to sprite1

	}

	public void FrenteSubindo ()
	{
		spriteRenderer.sprite = spritefrentesubindo; // otherwise change it back to sprite1

	}

	public void FrenteDescendo ()
	{
		spriteRenderer.sprite = spritefrentedescendo; // otherwise change it back to sprite1

	}

	public void TrazSubindo ()
	{
		spriteRenderer.sprite = spritetrassubindo; // otherwise change it back to sprite1

	}

	public void TrazDescendo ()
	{
		spriteRenderer.sprite = spritetrasdescendo; // otherwise change it back to sprite1

	}

}
