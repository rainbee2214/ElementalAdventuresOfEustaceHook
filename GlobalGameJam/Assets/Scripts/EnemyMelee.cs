using UnityEngine;
using System.Collections;

public class EnemyMelee : EnemyBase 
{
	[Header("Initial Values")]
	public int startHealth;
	public int startStrength;
	public int startAttackValue;

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
	GameObject player;
	Vector2 currentDirection;
	public Animator anim;

	void Start()
	{
		// Setup health, strength
		Health = startHealth;
		Strength = startStrength;

		// Setup view range
		AttackRange = startAttackRange;
		ViewRange = startViewRange;
		
		// Setup elemental & attack values
		ElementStat setup;
		setup.type = ElementType.Fire;
		setup.value = startAttackValue;
		ElementAttack = setup;
		
		// Setup resistance & weakness, ensure weakness is not the same as resistance
		BuffStat res;
		res.type = Utility.GetRandomEnum<ElementType>();
		res.value = resistanceMultiplier;
		Resistance = res;
		
		BuffStat weak;
		do
		{
			weak.type = Utility.GetRandomEnum<ElementType>();
		} while(weak.type == res.type);
		weak.value = weaknessMultiplier;
		Weakness = weak;

		// Create attack trigger
		CircleCollider2D attackTrigger = gameObject.AddComponent<CircleCollider2D>();
		attackTrigger.isTrigger = true;
		attackTrigger.radius = startAttackRange;
	}

	void FixedUpdate()
	{
		Move();
		// If player in sight
		if (playerInRange)
		{
			if (currentDirection == Vector2.right)
			{
				anim.SetBool("WalkRight", true);
				anim.SetBool("WalkLeft", false);
			} 
			else if (currentDirection == -Vector2.right)
			{
				anim.SetBool("WalkLeft", true);
				anim.SetBool("WalkRight", false);
			}
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime);
		}
		else
		{
			// Patrol
			// Move to one edge of ground, then move to other
		}
	}

	public void Move()
	{
		playerInRange = false;
		// Create raycasts to see if player is in line of sight
		hits[0] = Physics2D.Raycast(rightRay.position, Vector2.right, ViewRange);
		Debug.DrawRay(rightRay.position, Vector2.right * ViewRange);
		Debug.DrawRay(leftRay.position, -Vector2.right * ViewRange);
		hits[1] = Physics2D.Raycast(leftRay.position, -Vector2.right, ViewRange);

		for (int i = 0; i < hits.Length; i++)
		{
			if (playerInRange) break;
			if (hits[i].collider != null)
			{
				Debug.Log("Something hit" + hits[i].collider.tag);
				if (hits[i].collider.CompareTag("Player"))
				{
					player = hits[i].collider.gameObject;
					playerInRange = true;
					if (i == 0) currentDirection = Vector2.right;
					else currentDirection = -Vector2.right;
				}
			}
		}


	}

//	public override ElementStat GetAttack()
//	{
//		ElementStat attack = base.GetAttack();
//
//		return attack;
//	}

//	void OnTriggerEnter2D(Collider2D other)
//	{
//		if (other.CompareTag("Player"))
//		{
//			// Attack!
//				// attackinfo = GetAttack();
//				// player.takeDamage(attackinfo);
//		}
//	}
//
//	void OnCollisionEnter2D(Collision2D collision)
//	{
//		if (collision.gameObject.tag == "Hookshot")
//		{
//			// Get damage from player and fix below
//			ElementStat attack;
//			attack.type = ElementType.Fire;
//			attack.value = 1;
//			// Above to be replaced from player
//			TakeDamage(attack);
//		}
//	}
}
