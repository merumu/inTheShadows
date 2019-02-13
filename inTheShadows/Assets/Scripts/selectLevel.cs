using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectLevel : MonoBehaviour {

	public int level;
	private Vector3 target;
	private float speed = 8;

	void Start () {
		target = transform.position;
		level = 0;
	}
	
	void Update () {
		if (transform.position != target)
			transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
	}

	public void next()
	{
		if (level < 3 && Vector3.Distance(transform.position, target) < 5)
		{
			target = new Vector3(transform.position.x - 500, transform.position.y, transform.position.z);
		//	transform.Translate(new Vector3(-500, 0, 0));
			level++;
		}
	}

	public void prev()
	{
		if (level > 0 && Vector3.Distance(transform.position, target) < 5)
		{
			target = new Vector3(transform.position.x + 500, transform.position.y, transform.position.z);
		//	transform.Translate(new Vector3(500, 0, 0));
			level--;
		}
	}
}
