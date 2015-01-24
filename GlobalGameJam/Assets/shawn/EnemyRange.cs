using UnityEngine;
using System.Collections;

public class EnemyRange : EnemyBase 
{
	
	void Start () 
	{
		Health = 10;
		Strength = 10;
		ElementStat stats;

		stats.type = ElementType.Fire;
		stats.value = 2;
		ElementAttack = stats;

		BuffStat buff;
		buff.value = 1.2f;
		buff.type = ElementType.Water;
		Weakness = buff;

		buff.type = ElementType.Magic;
		buff.value = 0.2f;
		Resistance = buff;

		ViewRange = 10f;
		AttackRange = 5f;

		stats.type = ElementAttack.type;
		stats.value = 2;

		CircleCollider2D attackTrigger = gameObject.AddComponent<CircleCollider2D>();
		attackTrigger.isTrigger = true;
		attackTrigger.radius = AttackRange;
	}


	void FixedUpdate () 
	{
		
	}

	public void Move()
	{
		bool playerInRange = false;
		RaycastHit2D[] hits = new RaycastHit2D[3];
		// Create raycasts to see if player is in line of sight
		hits[0] = Physics2D.Raycast(transform.position, Vector2.right, ViewRange);
		hits[1] = Physics2D.Raycast(transform.position, -Vector2.right, ViewRange);
		hits[2] = Physics2D.Raycast(transform.position, Vector2.up, ViewRange);
		foreach (RaycastHit2D hit in hits)
		{
			if (playerInRange) break;
			if (hit.collider != null)
			{
				if (hit.collider.CompareTag("Player"))
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

	public override void TakeDamage(ElementStat damage)
	{
		//do take damage animation

		base.TakeDamage(damage);
	}


	public override ElementStat GetAttack ()
	{
		//Do attack animation

		return base.GetAttack ();
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
