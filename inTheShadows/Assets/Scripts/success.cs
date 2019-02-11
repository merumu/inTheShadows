using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class success : MonoBehaviour {

	public DragnRotate piece1;
	public DragnRotate piece2;
	public CanvasGroup victory;
	public bool multi;
	public ParticleSystem system;
	private bool play = true;
	
	void Update () {
		if (!multi && piece1.success)
		{
			piece1.successPos();
			victory.alpha = 1;
			victory.interactable = true;
			if (play)
			{
				system.Play(play);
				play = false;
			}
		}
		if (multi && piece1.success && piece2.success)
		{
			piece1.successPos();
			piece2.successPos();
			victory.alpha = 1;
			victory.interactable = true;
			if (play)
			{
				system.Play(play);
				play = false;
			}
		}
	}
}
