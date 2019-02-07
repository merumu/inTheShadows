using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class success : MonoBehaviour {

	public DragnRotate piece1;
	public DragnRotate piece2;
	public CanvasGroup victory;
	public bool multi;
	
	void Update () {
		if (!multi && piece1.success)
		{
			piece1.successPos();
			victory.alpha = 1;
			victory.interactable = true;
		}
		if (multi && piece1.success && piece2.success)
		{
			piece1.successPos();
			piece2.successPos();
			victory.alpha = 1;
			victory.interactable = true;
		}
	}
}
