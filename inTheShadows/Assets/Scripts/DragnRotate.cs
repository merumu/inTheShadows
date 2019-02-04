using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragnRotate : MonoBehaviour{

	private Vector3 positionTmp = Vector3.zero;

	void OnMouseDrag(){
		if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
		{
			if (positionTmp.x < Input.mousePosition.x)
				transform.rotation *= Quaternion.Euler(0,0,6);
			if (positionTmp.x > Input.mousePosition.x)
				transform.rotation *= Quaternion.Euler(0,0,-6);
		}
		if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
		{
			if (positionTmp.x < Input.mousePosition.x)
				transform.rotation *= Quaternion.Euler(-6,0,0);
			if (positionTmp.x > Input.mousePosition.x)
				transform.rotation *= Quaternion.Euler(6,0,0);
		}
		if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl))
		{
			if (positionTmp.x > Input.mousePosition.x)
				transform.Translate(0.1f,0,0);
			if (positionTmp.x < Input.mousePosition.x)
				transform.Translate(-0.1f,0,0);
			if (positionTmp.y > Input.mousePosition.y)
				transform.Translate(0,-0.1f,0);
			if (positionTmp.y < Input.mousePosition.y)
				transform.Translate(0,0.1f,0);
		}
		positionTmp = Input.mousePosition;
	}
}