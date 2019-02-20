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
	private AudioSource swipe;
	private Vector3 target;
	private float speed = 8;

	void Start () {
		swipe = left.GetComponent<AudioSource>();
		level = gm.lvl;
		transform.position = new Vector3(transform.position.x - Screen.width * level, transform.position.y, transform.position.z);
		shadows.transform.position = new Vector3(transform.position.x + 10, shadows.transform.position.y, shadows.transform.position.z);
		bg.transform.position = transform.position;
		target = transform.position;
	}
	
	void Update () {
		if (level == 6)
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
		shadows.transform.position = new Vector3(transform.position.x + shadows.transform.parent.transform.localPosition.x + 10, shadows.transform.position.y, shadows.transform.position.z);
		bg.transform.position = transform.position;
	}

	public void next()
	{
		if (level < 6 && Vector3.Distance(transform.position, target) < 5)
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