using UnityEngine;
using System.Collections;

public enum ElementType
{
	Fire,
	Water,
	Magic
};

public struct ElementStat 
{
	public ElementType type;
	public int value;
}

public struct BuffStat
{
	public ElementType type;
	public float value;
}
