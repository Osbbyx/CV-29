using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
	private Animator anim;
	public Transform weapon;

	private Vector2 moveAmount;

	public int health;

	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;

	public Animator hurtAnim;

	private SceneTransitions sceneTransitions;

	private bool pause;



	private void Start()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		sceneTransitions = FindObjectOfType<SceneTransitions>();
	}

	private void Awake()
	{
		pause = false;
	}
	private void Update()
	{
		Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		moveAmount = moveInput.normalized * speed;

		if (moveInput != Vector2.zero)
		{
			anim.SetBool("isRunning", true);
		}
		else
		{
			anim.SetBool("isRunning", false);
		}

		
	}

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
	}

	public void TakeDamage(int damageAmount)
	{
		health -= damageAmount;
		UpdateHealthUI(health);
		hurtAnim.SetTrigger("hurt");
		if (health <= 0)
		{
			Destroy(gameObject);
			sceneTransitions.LoadScene("Lose");
		}
	}

	public void ChangeWeapon(Weapon weaponToEquip)
	{
		Destroy(GameObject.FindGameObjectWithTag("Weapon"));
		Instantiate(weaponToEquip, weapon.transform.position, transform.rotation, weapon);
	}

	void UpdateHealthUI(int currentHealth)
	{
		for (int i = 0; i < hearts.Length; i++)
		{
			if(i < currentHealth)
			{
				hearts[i].sprite = fullHeart;
			}
			else
			{
				hearts[i].sprite = emptyHeart;
			}
		}
	}

	public void Heal (int healAmount)
	{
		if(health + healAmount > 5)
		{
			health = 5;
		}
		else
		{
			health += healAmount;
		}
		UpdateHealthUI(health);
	}
}
