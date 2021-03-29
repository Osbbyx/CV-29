using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
	public float speed;

	public float minX;
	public float maxX;
	public float minY;
	public float maxY;

	private void Start()
	{
		
	}

	private void Update()
	{
		if(playerTransform != null)
		transform.position = new Vector3(playerTransform.position.x,playerTransform.position.y,-10);
		/*	if(playerTransform != null)
			{
				float clampedX = Mathf.Clamp(playerTransform.position.x, minX, maxX);
				float clampedY = Mathf.Clamp(playerTransform.position.y, minY, maxY);
				transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX,clampedY), speed);
			}*/

	}
}
