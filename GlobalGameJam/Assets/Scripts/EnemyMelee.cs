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

	RaycastHit2D[] hits = new RaycastHit2D[3];
	bool playerInRange;

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
	}

	public void Move()
	{
		playerInRange = false;
		// Create raycasts to see if player is in line of sight
		hits[0] = Physics2D.Raycast(transform.position, Vector2.right, ViewRange);
		hits[1] = Physics2D.Raycast(transform.position, -Vector2.right, ViewRange);
		hits[2] = Physics2D.Raycast(transform.position, Vector2.up, ViewRange);
		foreach (RaycastHit2D h in hits)
		{
			if (playerInRange) break;
			if (h.collider != null)
			{
				if (h.collider.CompareTag("Player"))
				{
					playerInRange = true;
				}
			}
		}

		// If player in sight
		if (playerInRange)
		{
			// move towards player
		}
		else
		{
			// Patrol
			// Move to one edge of ground, then move to other
		}
	}

	public override ElementStat GetAttack()
	{
		ElementStat attack = base.GetAttack();

		return attack;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			// Attack!
				// attackinfo = GetAttack();
				// player.takeDamage(attackinfo);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Hookshot")
		{
			// Get damage from player and fix below
			ElementStat attack;
			attack.type = ElementType.Fire;
			attack.value = 1;
			// Above to be replaced from player
			TakeDamage(attack);
		}
	}
}
