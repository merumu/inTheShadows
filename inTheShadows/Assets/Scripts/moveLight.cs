using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLight : MonoBehaviour {

	private float speedX;
	private float speedY;
	
	void Update () {
		if (speedX > 0)
			speedX = Random.Range(0f, 0.1f);
		else
			speedX = Random.Range(-0.1f, 0f);
		if (speedY > 0)
			speedY = Random.Range(0f, 0.1f);
		else
			speedY = Random.Range(-0.1f, 0f);
		if (transform.localPosition.x < -50)
		{
			transform.localPosition = new Vector3 (-50, transform.localPosition.y, transform.localPosition.z);
			speedX *= -1;
		}
		if (transform.localPosition.x > 50)
		{
			transform.localPosition = new Vector3 (50, transform.localPosition.y, transform.localPosition.z);
			speedX *= -1;
		}
		if (transform.localPosition.y < -20)
		{
			transform.localPosition = new Vector3 (transform.localPosition.x, -20, transform.localPosition.z);
			speedY *= -1;
		}
		if (transform.localPosition.y > 0)
		{
			transform.localPosition = new Vector3 (transform.localPosition.x, 0, transform.localPosition.z);
			speedY *= -1;
		}
		transform.Translate(new Vector3(speedX,speedY,0));
	}
}
