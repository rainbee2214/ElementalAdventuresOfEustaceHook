using UnityEngine;
using System.Collections;

public class FireBoss : EnemyBase 
{
	[Header("Initial Values")]
	public int startHealth,
			   startStrength,
			   startAttackValue;

	public float startAttackRange, 
				 startViewRange;

	[Range(0.0f, 1.0f)]
	public float resistanceMultiplier;
	[Range(1.0f, 2.0f)]
	public float weaknessMultiplier;

	void Start () 
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
