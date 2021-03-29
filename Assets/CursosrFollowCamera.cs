using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursosrFollowCamera : MonoBehaviour
{

	
	private void Start()
	{
		Cursor.visible = false;
	}
	private void Update()
	{
		Vector3 screenpoint = Input.mousePosition;
		screenpoint.z = 10.0f;
		transform.position = Camera.main.ScreenToWorldPoint(screenpoint);
	}
}
