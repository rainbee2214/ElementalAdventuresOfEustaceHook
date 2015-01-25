using UnityEngine;
using System.Collections;

public class FireBoss : EnemyBase 
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


	// Raycasts to avoid a million objects
	RaycastHit2D[] hits = new RaycastHit2D[2];

	// Booleans for player in range
	bool playerInRange = false;
	bool playerInAttackRange = false;

	// player reference
	GameObject player;

	// current direction
	Vector2 currentDirection;

	// animator
	Animator anim;
	
	void Start () 
	{
		// Setup stats
		SetupFireBoss();

		// Get animator
		anim = gameObject.GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		LookForPlayer();

		// If the player is in line of sight
		if (playerInRange)
		{
			// If the player isn't in attack range
			if (!playerInAttackRange)
			{
				SetWalkDirection();

				// Physically move towards the player
				transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime);
			}
			else // Else the player is in attack range
			{
				Attack();
			}
		}
		else // Else player isn't in line of sight, patrol area
		{
//			int dir = Random.Range(0, 2);
//			if (dir = 0) currentDirection = 
		}

	}

	void LookForPlayer()
	{
		// Reset player in range boolean
		playerInRange = false;

		// Set our layer mask to only match the player layer
		int layerMask = 1 << LayerMask.NameToLayer("Player");

		// Create raycasts to see if player is in line of sight
		hits[0] = Physics2D.Raycast(transform.position, Vector2.right, ViewRange, layerMask);
			 Debug.DrawRay(transform.position, Vector2.right * ViewRange);
		hits[1] = Physics2D.Raycast(transform.position, -Vector2.right, ViewRange, layerMask);
			 Debug.DrawRay(transform.position, -Vector2.right * ViewRange);

		// Loop through raycasts to look for player
		for (int i = 0; i < hits.Length; i++)
		{
			if (playerInRange) break; // If already in range don't check other direction
			if (hits[i].collider != null)
			{
				if (hits[i].collider.CompareTag("Player"))
				{
					// Get player reference, set boolean to true, set direction
					player = hits[i].collider.gameObject;
					playerInRange = true;
					if (i == 0) currentDirection = Vector2.right;
					else currentDirection = -Vector2.right;
				}
			}
		}

		// If player is in view range, see if in attack range
		if (playerInRange)
		{
			// Create raycast for attack range
			hits[0] = Physics2D.Raycast(transform.position, currentDirection, AttackRange, layerMask);
				 Debug.DrawRay(transform.position, currentDirection * AttackRange, Color.red);

			// Check raycast for player in attack range, set boolean accordingly
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
	}

	void Attack()
	{
		// Stop walking
		anim.SetBool("WalkRight", false);
		anim.SetBool("WalkLeft", false);
		
		// FIXME
		// Set idle direction to current direction
//		if (currentDirection == Vector2.right)
//		{
//			anim.SetTrigger("IdleRight");
//		} 
//		else if (currentDirection == -Vector2.right)
//		{
//			anim.SetTrigger("IdleLeft");
//		}

		// Start animation
		anim.SetTrigger("Attack");
	}

	void SetWalkDirection()
	{
		// Set the current direction for animation
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
	}

	void SetupFireBoss()
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
		
		// Setup resistance & weakness
		BuffStat res;
		res.type = ElementType.Fire;
		res.value = resistanceMultiplier;
		Resistance = res;
		
		BuffStat weak;
		weak.type = ElementType.Water;
		weak.value = weaknessMultiplier;
		Weakness = weak;
	}

	void Die()
	{
		GameController.controller.bossController.removeMainBossResistance(ElementAttack.type);
	}
}
