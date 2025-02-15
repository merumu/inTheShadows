﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lockLevel : MonoBehaviour {

	public gameManager gm;
	public List<GameObject> level;
	public List<GameObject> shadows;
	public List<GameObject> timer;
	public Font arial;
	[HideInInspector] public Font none;
	private int cinematic = 0;
	private int i = 0;
	public Image unlock;
	private Animation anim;
	private AudioSource unlockSound;

	void Start () {
		unlockSound = GetComponent<AudioSource>();
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
			List<string> puzzleTime = gm.GetStrings("puzzleTime");
			foreach (int item in puzzleLock)
			{
				if (puzzleTime[i] != "--")
					timer[i].GetComponent<Text>().text = "Best : " + puzzleTime[i] + "s";
				else
					timer[i].GetComponent<Text>().text = "Best : " + puzzleTime[i];
				if (item == 0 || item == 1)
				{
					level[i].GetComponent<Button>().interactable = false;
					shadows[i].GetComponent<Text>().font = none;
					timer[i].GetComponent<Text>().font = none;
				}
				else
				{
					level[i].GetComponent<Button>().interactable = true;
					shadows[i].GetComponent<Text>().font = arial;
					timer[i].GetComponent<Text>().font = arial;
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
		if (gm.lvl != 0)
		{
			anim = unlock.GetComponent<Animation>();
			anim.Play();
			if (gm.son)
				unlockSound.Play();
		}
	}
}
