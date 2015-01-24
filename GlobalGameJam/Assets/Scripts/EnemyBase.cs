using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour
{
	#region Properties

	int health;
	public int Health
	{
		get { return health; }
		set { health += value; }
	}

	int strength;
	public int Strength
	{
		get { return strength; }
		set { strength += value; }
	}

	float attackRange;
	public float AttackRange
	{
		get { return attackRange; }
		set { attackRange = value; }
	}

	float viewRange;
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
		case ElementType.Fire:
			if (resistance.type == ElementType.Fire) finalDamage *= resistance.value;
			if (weakness.type == ElementType.Fire) finalDamage *= weakness.value;
			break;
		case ElementType.Water:
			if (resistance.type == ElementType.Water) finalDamage *= resistance.value;
			if (weakness.type == ElementType.Water) finalDamage *= weakness.value;
			break;
		case ElementType.Magic:
			if (resistance.type == ElementType.Magic) finalDamage *= resistance.value;
			if (weakness.type == ElementType.Magic) finalDamage *= weakness.value;
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
