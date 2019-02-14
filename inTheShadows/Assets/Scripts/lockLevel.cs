using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lockLevel : MonoBehaviour {

	public gameManager gm;
	public List<GameObject> level;
	public List<GameObject> shadows;
	public Font m_Font;
	private int cinematic = 0;
	private int i = 0;

	void Start () {
		if (gm.mode)
		{
			List<int> puzzleLock = gm.GetInts("puzzleLock");
			foreach (int item in puzzleLock)
			{
				if (item == 0)
				{
					level[i].GetComponent<Button>().interactable = false;
					shadows[i].GetComponent<Text>().font = m_Font;
				}
				if (item == 1)
					cinematic = i;
				i++;
			}
			if (cinematic != 0)
			{
				unlockLevel();
				puzzleLock[cinematic] = 2;
				gm.SetInts("puzzleLock", puzzleLock);
				cinematic = 0;
			}
		}
	}
	
	void Update () {
	}

	private void unlockLevel()
	{
		Debug.Log("unlock next level");
	}
}
