using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

	[HideInInspector]
	public Transform player;

	public float speed;
	public float timeBetweenAtack;
	public int damage;

	public int pickupChance;
	public GameObject[] pickUps;

	public int healthPickupChance;
	public GameObject[] healthPickUp;

	public GameObject deathEffect;

	public virtual void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	public void TakeDamage(int damageAmount)
	{
		health -= damageAmount;

		if(health <= 0)
		{
			int randomNumber = Random.Range(0, 101);
			if(randomNumber < pickupChance)
			{
				GameObject randomPickup = pickUps[Random.Range(0, pickUps.Length)];
				Instantiate(randomPickup, transform.position, transform.rotation);
			}

			int randHealth = Random.Range(0, 101);
			if(randHealth < healthPickupChance)
			{
				GameObject healthPickUpRamdom = healthPickUp[Random.Range(0, healthPickUp.Length)];
				Instantiate(healthPickUpRamdom, transform.position, transform.rotation);
			}

			Instantiate(deathEffect, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}

	
}
