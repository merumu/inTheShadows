using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lockLevel : MonoBehaviour {

	public gameManager gm;
	public List<GameObject> level;
	public List<GameObject> shadows;
	public Font arial;
	public Font none;
	private int cinematic = 0;
	private int i = 0;
	public Image unlock;
	private Animation anim;

	void Start () {
		if (gm.mode)
		{
			setLock();
			StartCoroutine(endAnim());
		}
	}

	IEnumerator endAnim()
	{
		yield return new WaitForSeconds(0.6f);
		setLock();
	}
	
	private void setLock()
	{
		if (gm.mode)
		{
			i = 0;
			List<int> puzzleLock = gm.GetInts("puzzleLock");
			foreach (int item in puzzleLock)
			{
				if (item == 0 || item == 1)
				{
					level[i].GetComponent<Button>().interactable = false;
					shadows[i].GetComponent<Text>().font = none;
				}
				else
				{
					level[i].GetComponent<Button>().interactable = true;
					shadows[i].GetComponent<Text>().font = arial;
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

	private void unlockLevel()
	{
		anim = unlock.GetComponent<Animation>();
		anim.Play();
	}
}
