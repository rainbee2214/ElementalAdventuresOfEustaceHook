using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour
{
	#region Properties

	int health = 10;
	public int Health
	{
		get { return health; }
		set { health += value; }
	}

	int strength = 1;
	public int Strength
	{
		get { return strength; }
		set { strength += value; }
	}

	float attackRange = 1f;
	public float AttackRange
	{
		get { return attackRange; }
		set { attackRange = value; }
	}

	float viewRange = 1f;
	public float ViewRange
	{
		get { return viewRange; }
		set { viewRange = value; }
	}

	ElementStat elementAttack;
	public ElementStat ElementAttack
	{
		get { return elementAttack; }
		set { elementAttack = value; }
	}

	// value should be from 1.0-2.0 (see take damage)
	BuffStat weakness;
	public BuffStat Weakness
	{
		get { return weakness; }
		set { weakness = value; }
	}

	// value should be from 0.0-1.0 (see take damage)
	BuffStat resistance;
	public BuffStat Resistance
	{
		get { return resistance; }
		set { resistance = value; }
	}

	#endregion

	public virtual void TakeDamage(ElementStat damage)
	{
		float finalDamage = damage.value;
		switch(damage.type)
		{
		case Element.Fire:
			if (resistance.type == Element.Fire) finalDamage *= resistance.value;
			if (weakness.type == Element.Fire) finalDamage *= weakness.value;
			break;
		case Element.Water:
			if (resistance.type == Element.Water) finalDamage *= resistance.value;
			if (weakness.type == Element.Water) finalDamage *= weakness.value;
			break;
		case Element.Magic:
			if (resistance.type == Element.Magic) finalDamage *= resistance.value;
			if (weakness.type == Element.Magic) finalDamage *= weakness.value;
			break;
		}

		// check for complete damage resistance
		if (finalDamage > 0) health -= (int)finalDamage;
	}

	public virtual ElementStat GetAttack()
	{
		ElementStat attack = elementAttack;
		attack.value += strength;
		return attack;
	}
}
