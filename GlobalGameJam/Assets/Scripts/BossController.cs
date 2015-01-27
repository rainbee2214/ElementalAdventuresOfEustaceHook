using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour 
{
	// Reference to main boss
	// References to mini bosses
	FireBoss fireBoss;
	WaterBoss waterBoss;
	MagicBoss magicBoss;
	
	public void RemoveResistance(Element toRemove)
	{
		switch(toRemove)
		{
		case Element.Fire:
			//boss.removeResistance(Element.Fire);
			break;
		case Element.Magic:
			//boss.removeResistance(Element.Magic);
			break;
		case Element.Water:
			//boss.removeResistance(Element.Water);
			break;
		}
	}	
}
