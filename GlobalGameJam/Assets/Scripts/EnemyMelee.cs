using UnityEngine;
using System.Collections;

public class EnemyMelee : EnemyBase 
{

	public void Move()
	{
		// If player in sight
			// move towards player
			// if player in range
				//attack the player
		// else no player in range
			// Patrol
			// Move to one edge of ground, then move to other
	}

	public override ElementStat GetAttack()
	{
		ElementStat attack = base.GetAttack();

		//Do attack animation

		return attack;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Hookshot")
		{
			// Get damage from player and fix below
			ElementStat attack;
			attack.type = ElementType.Fire;
			attack.value = 1;
			TakeDamage(attack);
		}
	}
}
