using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLight : MonoBehaviour {

	private float speedX;
	private float speedY;

	void Start () {
		
	}
	
	void Update () {
		transform.Translate(new Vector3(0,-0.1,0));
	}
}
