using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour 
{
	// Reference to main boss
	// References to mini bosses
	
	public void removeMainBossResistance(ElementType toRemove)
	{
		switch(toRemove)
		{
		case ElementType.Fire:
			//boss.removeResistance(ElementType.Fire);
			break;
		case ElementType.Magic:
			//boss.removeResistance(ElementType.Magic);
			break;
		case ElementType.Water:
			//boss.removeResistance(ElementType.Water);
			break;
		}
	}	
}
