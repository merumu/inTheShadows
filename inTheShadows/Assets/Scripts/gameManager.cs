using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

	public static gameManager gm;
	public static int level;
	public selectLevel select;
	public List<GameObject> puzzle;

	void Awake () {
		if (gm == null)
			gm = this;
	}

	void Start () {
		if (puzzle.Count > 0)
			puzzle[level].SetActive(true);
	}
	
	void Update () {
		if (select)
			level = select.level;
	}
}