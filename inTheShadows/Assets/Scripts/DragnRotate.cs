using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragnRotate : MonoBehaviour{

	public bool rotX;
	public bool rotZ;
	public bool moveY;
	private float timer = 0;
	private Vector3 positionTmp = Vector3.zero;

	void Update(){
		solution();
	}

	private void solution()
	{
		RaycastHit hit;
		Vector3 forward = transform.TransformDirection(Vector3.down * 10000);
		Ray ray = new Ray(transform.position, forward);
		if (Physics.Raycast(ray, out hit, 10, 1 << LayerMask.NameToLayer("solution")))
        {
          	if (hit.collider)
           		timer += Time.deltaTime;
        	else
        		timer = 0;
		} 
		Debug.DrawLine (transform.position, forward, Color.red);
		if (timer > 1.5f)
		{
			Debug.Log(hit.collider.gameObject.name);
			timer = 0;
		}
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