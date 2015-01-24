using UnityEngine;
using System.Collections;

public class EnemyRange : EnemyBase 
{

	public void Move()
	{
		//move to player if in view range of that player
		//attack if within attackRange of that player
	}


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
	}

	void FixedUpdate () 
	{
		
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
}
