using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectLevel : MonoBehaviour {

	public gameManager gm;
	[HideInInspector] public int level;
	public GameObject shadows;
	public GameObject bg;
	public Button right;
	public Button left;
	public Text finalText;
	public Text finalTextShadows;
	private AudioSource finalSound;
	private AudioSource swipe;
	private Vector3 target;
	private float speed = 8;
	private bool final = false;

	void Start () {
		swipe = left.GetComponent<AudioSource>();
		finalSound = finalText.GetComponent<AudioSource>();
		level = gm.lvl;
		transform.position = new Vector3(transform.position.x - Screen.width * level, transform.position.y, transform.position.z);
		shadows.transform.position = new Vector3(transform.position.x + 10, shadows.transform.position.y, shadows.transform.position.z);
		bg.transform.position = transform.position;
		target = transform.position;
	}
	
	void Update () {
		finalScore();
		if ((level == 8 && !final) || level == 9)
			right.interactable = false;
		else
			right.interactable = true;
		if (level == 0)
			left.interactable = false;
		else
			left.interactable = true;
		moveToTarget();
	}

	private void finalScore()
	{
		if (gm.mode)
		{
			List<int> puzzleLock = gm.GetInts("puzzleLock");
			if (puzzleLock[puzzleLock.Count - 1] == 3)
				final = true;
		}
		if (final)
		{
			float score = 0;
			List<string> puzzleTime = gm.GetStrings("puzzleTime");
			foreach (string item in puzzleTime)
			{
				score += float.Parse(item);
			}
			finalText.text = "Congratulations !\n\nTotal Score :\n" + score + "s\n\n";
			if (score < 30)
				finalText.text += "You're a Cheater !";
			else if (score < 120)
				finalText.text += "You're a Pro !";
			else if (score < 600)
				finalText.text += "Well Done !";
			else
				finalText.text += "That's Bad...";
			finalTextShadows.text = finalText.text;
		}
		if (level == 9 && gm.son && !finalSound.isPlaying)
			finalSound.Play();
		else if (level != 9)
			finalSound.Stop();
	}

	private void moveToTarget()
	{
		transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
		shadows.transform.position = new Vector3(transform.position.x + shadows.transform.parent.transform.localPosition.x + 10, shadows.transform.position.y, shadows.transform.position.z);
		bg.transform.position = transform.position;
	}

	public void next()
	{
		if ((level < 8 || final) && level < 9 && Vector3.Distance(transform.position, target) < 5)
		{
			if (gm.son)
				swipe.Play();
			target = new Vector3(transform.position.x - Screen.width, transform.position.y, transform.position.z);
			level++;
		}
	}

	public void prev()
	{
		if (level > 0 && Vector3.Distance(transform.position, target) < 5)
		{
			if (gm.son)
				swipe.Play();
			target = new Vector3(transform.position.x + Screen.width, transform.position.y, transform.position.z);
			level--;
		}
	}
}