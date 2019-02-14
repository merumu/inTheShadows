using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectLevel : MonoBehaviour {

	public int level;
	public GameObject shadows;
	public Button right;
	public Button left;
	private Vector3 target;
	private float speed = 8;

	void Start () {
		target = transform.position;
		level = 0;
	}
	
	void Update () {
		if (level == 3)
			right.interactable = false;
		else
			right.interactable = true;
		if (level == 0)
			left.interactable = false;
		else
			left.interactable = true;
		moveToTarget();
	}

	private void moveToTarget()
	{
		transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
		shadows.transform.position = new Vector3(transform.position.x + shadows.transform.parent.transform.localPosition.x, shadows.transform.position.y, shadows.transform.position.z);
	}

	public void next()
	{
		if (level < 3 && Vector3.Distance(transform.position, target) < 5)
		{
			target = new Vector3(transform.position.x - 502, transform.position.y, transform.position.z);
			level++;
		}
	}

	public void prev()
	{
		if (level > 0 && Vector3.Distance(transform.position, target) < 5)
		{
			target = new Vector3(transform.position.x + 502, transform.position.y, transform.position.z);
			level--;
		}
	}
}