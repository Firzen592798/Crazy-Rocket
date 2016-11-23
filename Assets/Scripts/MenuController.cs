using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	public TextMesh jogar;
	public TextMesh sobre;
	// Use this for initialization
	void Start () {
		jogar = jogar.GetComponent<TextMesh> ();
		sobre = sobre.GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Jogar(){
		Application.LoadLevel ("Main");
	}
	public void Sobre(){
		Application.LoadLevel ("Sobre");
	}
}
