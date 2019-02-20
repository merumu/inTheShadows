using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class success : MonoBehaviour {

	public gameManager gm;
	public DragnRotate piece1;
	public DragnRotate piece2;
	public CanvasGroup victory;
	public CanvasGroup escMenu;
	public bool multi;
	public ParticleSystem system;
	public Text timeText;
	private bool play = true;
	private int konami;
	private float timer;
	private AudioSource ticTacSound;
	private AudioSource victorySound;
	private AudioSource fireworkSound;

	void Start () {
		ticTacSound = escMenu.GetComponent<AudioSource>();
		victorySound = victory.GetComponent<AudioSource>();
		fireworkSound = system.GetComponent<AudioSource>();
		if (gm.son)
			ticTacSound.Play();
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && victory.alpha == 0)
			escapeMenu();
		levelTimer();
		win();
		konamiCode();
	}
	
	private void escapeMenu()
	{
		if (escMenu.alpha == 0)
			{
				if (gm.son)
					ticTacSound.Stop();
				escMenu.alpha = 1;
				escMenu.interactable = true;
				escMenu.blocksRaycasts = true;
			}
			else
			{
				if (gm.son)
					ticTacSound.Play();
				escMenu.alpha = 0;
				escMenu.interactable = false;
				escMenu.blocksRaycasts = false;
			}
	}

	private void levelTimer(){
		if (escMenu.alpha == 0)
			timer += Time.deltaTime;
		if (play)
			timeText.text = "Time : " + (Mathf.Floor(timer * 100) / 100).ToString() + "s";
	}

	private void win(){
		if (escMenu.alpha == 0)
		{
			if ((!multi && piece1.success) || (!multi && konami == 6))
			{
				piece1.successPos();
				victory.alpha = 1;
				victory.interactable = true;
				victory.blocksRaycasts = true;
				if (play)
				{
					if (gm.mode)
						gm.saveProgress(timer);
					system.Play(play);
					if (gm.son)
					{
						ticTacSound.Stop();
						victorySound.Play();
						StartCoroutine(beginSound());
					}
					play = false;
				}
			}
			if ((multi && piece1.success && piece2.success) || (multi && konami == 6))
			{
				piece1.successPos();
				piece2.successPos();
				victory.alpha = 1;
				victory.interactable = true;
				victory.blocksRaycasts = true;
				if (play)
				{
					if (gm.mode)
						gm.saveProgress(timer);
					system.Play(play);
					if (gm.son)
					{
						ticTacSound.Stop();
						victorySound.Play();
						StartCoroutine(beginSound());
					}
					play = false;
				}
			}
		}
	}

	IEnumerator beginSound()
	{
		yield return new WaitForSeconds(1.2f);
		fireworkSound.Play();
	}

	private void konamiCode(){
		if (konami != 6)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				if (konami == 0)
					konami++;
				else
					konami = 0;
			}
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				if (konami == 1)
					konami++;
				else
					konami = 0;
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if (konami == 2)
					konami++;
				else
					konami = 0;
			}
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				if (konami == 3)
					konami++;
				else
					konami = 0;
			}
			if (Input.GetKeyDown("a"))
			{
				if (konami == 4)
					konami++;
				else
					konami = 0;
			}
			if (Input.GetKeyDown("b"))
			{
				if (konami == 5)
					konami++;
				else
					konami = 0;
			}
		}
	}
}
