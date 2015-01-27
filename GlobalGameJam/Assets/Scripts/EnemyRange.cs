using UnityEngine;
using System.Collections;

public class EnemyRange : EnemyBase 
{
	
	[Header("Initial Values")]
	public int startHealth;
	public int startStrength;
	public int startAttackValue;
	public float attackDelay;
	float nextAttackTime;

	WeaponController weapon;
	
	public float startAttackRange, 
	startViewRange;
	
	[Range(0.0f, 1.0f)]
	public float resistanceMultiplier;
	[Range(1.0f, 2.0f)]
	public float weaknessMultiplier;
	
	[Header("Send Rays From")]
	public Transform leftRay;
	public Transform rightRay;
	
	RaycastHit2D[] hits = new RaycastHit2D[2];
	bool playerInRange;
	bool playerInAttackRange = false;
	GameObject player;
	Vector2 currentDirection;
	public Animator anim;
	
	void Start()
	{

		weapon = GetComponent<WeaponController>();

		currentDirection = Vector2.right;
		nextAttackTime = Time.time;

		anim = GetComponent<Animator>();
		// Setup health, strength
		Health = startHealth;
		Strength = startStrength;
		
		// Setup view range
		AttackRange = startAttackRange;
		ViewRange = startViewRange;
		
		// Setup elemental & attack values
		ElementStat setup;
		setup.type = Element.Fire;
		setup.value = startAttackValue;
		ElementAttack = setup;
		
		// Setup resistance & weakness, ensure weakness is not the same as resistance
		BuffStat res;
		res.type = Utility.GetRandomEnum<Element>();
		res.value = resistanceMultiplier;
		Resistance = res;
		
		BuffStat weak;
		do
		{
			weak.type = Utility.GetRandomEnum<Element>();
		} while(weak.type == res.type);
		weak.value = weaknessMultiplier;
		Weakness = weak;
	}
	
	void FixedUpdate()
	{
		Move();
		// If player in sight
		if (playerInRange)
		{
			if (!playerInAttackRange)
			{
				if (currentDirection == Vector2.right)
				{
					anim.SetBool("WalkRight", true);
					anim.SetBool("WalkLeft", false);
					//attackTrigger.center = new Vector2(2.7f, 0f);
				} 
				else if (currentDirection == -Vector2.right)
				{
					anim.SetBool("WalkLeft", true);
					anim.SetBool("WalkRight", false);
					//attackTrigger.center = new Vector2(0f, 0f);
				}
				transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime);
			}
			else
			{
				if(nextAttackTime < Time.time) 
				{ 
					anim.SetBool("WalkRight", false);
					anim.SetBool("WalkLeft", false);
					anim.SetTrigger("Attack");
					FireWeapon();
					nextAttackTime = Time.time + attackDelay;
				}
			}
		}
		else
		{
			// Patrol
			// Move to one edge of ground, then move to other
			anim.SetBool("WalkRight", false);
			anim.SetBool("WalkLeft", false);
		}
	}

	public void FireWeapon()
	{
		weapon.Fire(transform.position, transform.position, currentDirection);
	}

	
	public void Move()
	{
		int layerMask = 1 << LayerMask.NameToLayer("Player");
		
		playerInRange = false;
		// Create raycasts to see if player is in line of sight
		hits[0] = Physics2D.Raycast(transform.position, Vector2.right, ViewRange, layerMask);
		Debug.DrawRay(transform.position, Vector2.right * ViewRange);
		hits[1] = Physics2D.Raycast(transform.position, -Vector2.right, ViewRange, layerMask);
		Debug.DrawRay(transform.position, -Vector2.right * ViewRange);
		
		for (int i = 0; i < hits.Length; i++)
		{
			if (playerInRange) break;
			if (hits[i].collider != null)
			{
//				Debug.Log("Something hit" + hits[i].collider.tag);
				if (hits[i].collider.CompareTag("Player"))
				{
					player = hits[i].collider.gameObject;
					playerInRange = true;
					if (i == 0) currentDirection = Vector2.right;
					else currentDirection = -Vector2.right; 
				}
			}
		}

		// Do attack range raycast
		hits[0] = Physics2D.Raycast(transform.position, currentDirection, AttackRange, layerMask);
		Debug.DrawRay(transform.position, currentDirection * AttackRange, Color.red);
		if (hits[0].collider != null)
		{
			if (hits[0].collider.CompareTag("Player"))
			{
				playerInAttackRange = true;
			}
			else playerInAttackRange = false;
		}
		else playerInAttackRange = false;
		
		
	}
	
	public override ElementStat GetAttack()
	{
		ElementStat attack = base.GetAttack();
		
		return attack;
	}
	
//	void OnTriggerEnter2D(Collider2D other)
//	{
//		if (other.CompareTag("Player"))
//		{
//			playerInAttackRange = true;
//			// Attack!
//			// attackinfo = GetAttack();
//			// player.takeDamage(attackinfo);
//		}
//	}
	
//	void OnTriggerExit2D(Collider2D other)
//	{
//		if (other.CompareTag("Player"))
//		{
//			playerInAttackRange = false;
//		}
//	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Hookshot")
		{
			// Get damage from player and fix below
			ElementStat attack;
			attack.type = Element.Fire;
			attack.value = 1;
			// Above to be replaced from player
			TakeDamage(attack);
		}
	}
}
