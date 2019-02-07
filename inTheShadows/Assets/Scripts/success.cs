using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class success : MonoBehaviour {

	public DragnRotate piece1;
	public DragnRotate piece2;

	public bool multi;
	
	void Update () {
		if (!multi && piece1.success)
			piece1.successPos();
		if (multi && piece1.success && piece2.success)
		{
			piece1.successPos();
			piece2.successPos();
		}
	}
}
