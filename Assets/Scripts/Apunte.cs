using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apunte : MonoBehaviour
{
  

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + 121, Vector3.forward);
        transform.rotation = rotation;
    }
}
