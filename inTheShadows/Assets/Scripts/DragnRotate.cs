using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragnRotate : MonoBehaviour{

	public bool rotX;
	public bool rotZ;
	public bool moveY;
	public bool mirror;
	public Vector3 win;
	private bool success = false;
	private float timer = 0;
	private Vector3 positionTmp = Vector3.zero;

	void Update(){
		if (!success)
			solution();
		if (success)
			successPos();
	}

	private void successPos()
	{
		if (timer < 0)
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(win), 10f);
		else if (timer > 0)
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(win.x + 90, win.y, win.z)), 10f);
		Debug.Log("Success !");
	}

	private void solution()
	{
		RaycastHit hit;
		Vector3 forward = transform.TransformDirection(Vector3.down * 10000);
		Ray ray = new Ray(transform.position, forward);
		Vector3 forward2 = transform.TransformDirection(Vector3.up * 10000);
		Ray ray2 = new Ray(transform.position, forward2);
		if (Physics.Raycast(ray, out hit, 10, 1 << LayerMask.NameToLayer("solution")))
        {
          	if (hit.collider)
           		timer += Time.deltaTime;
		}
		else if (mirror && Physics.Raycast(ray2, out hit, 10, 1 << LayerMask.NameToLayer("solution")))
		{
			if (hit.collider)
           		timer -= Time.deltaTime;
		}
		else
			timer = 0;
		if (timer > 0.5f || timer < -0.5f)
			success = true;
		Debug.DrawLine (transform.position, forward, Color.red);
		if (mirror)
			Debug.DrawLine (transform.position, forward2, Color.red);
	}

	void OnMouseDrag(){
		if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl) && rotZ)
		{
			if (positionTmp.x < Input.mousePosition.x)
				transform.rotation *= Quaternion.Euler(0,0,4);
			if (positionTmp.x > Input.mousePosition.x)
				transform.rotation *= Quaternion.Euler(0,0,-4);
		}
		if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl) && rotX)
		{
			if (positionTmp.x < Input.mousePosition.x)
				transform.rotation *= Quaternion.Euler(-4,0,0);
			if (positionTmp.x > Input.mousePosition.x)
				transform.rotation *= Quaternion.Euler(4,0,0);
		}
		if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl) && moveY)
		{
			//if (positionTmp.x > Input.mousePosition.x)
			//	transform.Translate(Vector3.left * 0.2f, Space.World);
			//if (positionTmp.x < Input.mousePosition.x)
			//	transform.Translate(Vector3.right * 0.2f, Space.World);
			if (positionTmp.y < Input.mousePosition.y && transform.position.y < 5f)
				transform.Translate(Vector3.up * 0.2f, Space.World);
			if (positionTmp.y > Input.mousePosition.y && transform.position.y > -6f)
				transform.Translate(Vector3.down * 0.2f, Space.World);
		}
		positionTmp = Input.mousePosition;
	}
}