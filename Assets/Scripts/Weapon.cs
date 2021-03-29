using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    public float timeBetweenShots;

    private float shotTime;

    Animator cameraAnim;

	private void Start()
	{
        cameraAnim = Camera.main.GetComponent<Animator>();
	}

	void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + 121, Vector3.forward);
        transform.rotation = rotation;

		if (Input.GetMouseButton(0))
		{
            if(Time.time >= shotTime)
			{
                if(shotPoint != null)
				{
                    Instantiate(projectile, shotPoint.position, shotPoint.rotation);
                    cameraAnim.SetTrigger("shake");
                    shotTime = Time.time + timeBetweenShots;
                }
                
			}
		}
    }
}
