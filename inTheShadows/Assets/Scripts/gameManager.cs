using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

	public static gameManager gm;
	public static int level;

	void Awake () {
		if (gm == null)
			gm = this;
		Debug.Log("Awake");
	}

	void Start () {
		Debug.Log("start");
	}
	
	void Update () {
	}
}