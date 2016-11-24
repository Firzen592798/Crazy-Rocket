using UnityEngine;
using System.Collections;

public class backgroundscroll : MonoBehaviour {




	
	// Update is called once per frame
	void Update () {
		MeshRenderer mr = GetComponent<MeshRenderer> ();
		Material mat = mr.material;
		Vector2 offset = mat.mainTextureOffset;
		offset.x += Time.deltaTime / 5f;
		mat.mainTextureOffset = offset;

	
	}
}
