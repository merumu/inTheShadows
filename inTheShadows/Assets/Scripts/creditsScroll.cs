using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditsScroll : MonoBehaviour {

	public GameObject shadows;
	
	void Update () {
		transform.Translate(0,1f,0);
		shadows.transform.Translate(0,1f,0);
	}
}
