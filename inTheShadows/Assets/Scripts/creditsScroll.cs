using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditsScroll : MonoBehaviour {

	public GameObject shadows;
	
	void Update () {
		if (transform.position.y < Screen.height * 2.9f)
		{
			transform.Translate(0,1f,0);
			shadows.transform.Translate(0,1f,0);
		}
	}
}
