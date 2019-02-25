using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragnRotate : MonoBehaviour{

	public bool rotX;
	public bool rotY;
	public bool moveY;
	public bool mirror;
	public Vector3 raydir;
	public Vector3 win;
	[HideInInspector] public bool success = false;
	[HideInInspector] public bool end = false;
	private float timer = 0;
	private Vector3 positionTmp = Vector3.zero;

	void Update(){
		if (!end)
			solution();
	}

	public void successPos()
	{
		if (timer < 0)
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(win), 5f);
		else if (timer >= 0)
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(win.x, win.y + 180, win.z)), 5f);
		if (moveY)
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 0.5f, transform.position.z), 0.1f);
		end = true;
	}

	private void solution()
	{
		RaycastHit hit;
		Vector3 forward = transform.TransformDirection(raydir * 10000);
		Ray ray = new Ray(transform.position, forward);
		Vector3 forward2 = transform.TransformDirection(raydir * -10000);
		Ray ray2 = new Ray(transform.position, forward2);
		if (Physics.Raycast(ray, out hit, 100, 1 << LayerMask.NameToLayer("solution")) && (!moveY || Vector3.Angle(forward, Vector3.back) < 10f))
        {
          	if (hit.collider)
           		timer += Time.deltaTime;
		}
		else if (mirror && Physics.Raycast(ray2, out hit, 100, 1 << LayerMask.NameToLayer("solution")))
		{
			if (hit.collider)
           		timer -= Time.deltaTime;
		}
		else
		{
			timer = 0;
			success = false;
		}
		if (timer > 0.5f || timer < -0.5f)
			success = true;
		Debug.DrawLine (transform.position, forward, Color.red);
		if (mirror)
			Debug.DrawLine (transform.position, forward2, Color.red);
	}

	void OnMouseDrag(){
		if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl) && rotY)
		{
			if (positionTmp.x < Input.mousePosition.x)
				transform.rotation *= Quaternion.Euler(0,-4,0);
			if (positionTmp.x > Input.mousePosition.x)
				transform.rotation *= Quaternion.Euler(0,4,0);
		}
		if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl) && rotX)
		{
			if (positionTmp.x < Input.mousePosition.x)
				transform.rotation *= Quaternion.Euler(-4,0,0);
			if (positionTmp.x > Input.mousePosition.x)
				transform.rotation *= Quaternion.Euler(4,0,0);
		}
		if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl) && moveY)
		{
			if (positionTmp.y < Input.mousePosition.y && transform.position.y < 5f)
				transform.Translate(Vector3.up * 0.2f, Space.World);
			if (positionTmp.y > Input.mousePosition.y && transform.position.y > -5f)
				transform.Translate(Vector3.down * 0.2f, Space.World);
		}
		positionTmp = Input.mousePosition;
	}
}