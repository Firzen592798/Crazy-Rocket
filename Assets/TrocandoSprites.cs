using UnityEngine;
using System.Collections;

public class TrocandoSprites : MonoBehaviour {

	public Sprite spriteparado; // Drag your first sprite here
	public Sprite spritesubindo; // Drag your second sprite here
	public Sprite spritedescendo; // Drag your second sprite here

	private SpriteRenderer spriteRenderer; 

	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
			spriteRenderer.sprite = spriteparado; // set the sprite to sprite1
	}

	//void Update ()
	//{
	//	if (Input.GetKeyDown (KeyCode.UpArrow)) // If the space bar is pushed down
	//	{
	//		Subindo (); // call method to change sprite
	//	}
	//	if (Input.GetKeyDown (KeyCode.DownArrow)) // If the space bar is pushed down
	//	{
	//		Descendo (); // call method to change sprite
	//	}
	//}

	public void Subindo ()
	{
		if (spriteRenderer.sprite == spriteparado) // if the spriteRenderer sprite = sprite1 then change to sprite2
		{
			spriteRenderer.sprite = spritesubindo;
		}
		else
		{
			spriteRenderer.sprite = spriteparado; // otherwise change it back to sprite1
		}
	}

	public void Descendo ()
	{
		if (spriteRenderer.sprite == spriteparado) // if the spriteRenderer sprite = sprite1 then change to sprite2
		{
			spriteRenderer.sprite = spritedescendo;
		}
		else
		{
			spriteRenderer.sprite = spriteparado; // otherwise change it back to sprite1
		}
	}

	public void Parado ()
	{
		spriteRenderer.sprite = spriteparado; // otherwise change it back to sprite1
		
	}
}
