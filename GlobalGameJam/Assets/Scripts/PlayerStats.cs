using UnityEngine;
using System.Collections;

public class PlayerStats
{
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

	int armor;
	public int Armor
	{
		get { return armor; }
		set { armor += value; }
	}

	ElementStat fireStat;
	public ElementStat FireStat
	{
		get { return fireStat; }
		set { fireStat = value; }
	}

	ElementStat waterStat;
	public ElementStat WaterStat
	{
		get { return waterStat; }
		set { waterStat = value; }
	}

	ElementStat magicStat;
	public ElementStat MagicStat
	{
		get { return magicStat; }
		set { magicStat = value; }
	}

	int hookRange;
	public int HookRange
	{
		get { return hookRange; }
		set { hookRange += value; }
	}
}
