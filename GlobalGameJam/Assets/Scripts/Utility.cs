using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ElementType
{
	Fire,
	Water,
	Magic
};

/// <summary>
/// Element stat, used for attack type and value
/// </summary>
public struct ElementStat 
{
	public ElementType type;
	public int value;
}

/// <summary>
/// Buff stat, used for resistance/weakness type and value
/// </summary>
public struct BuffStat
{
	public ElementType type;
	public float value;
}

public static class Utility
{
	/// <summary>
	/// Gets a random enum from the specified generic
	/// </summary>
	/// <typeparam name="T">The enum type to get from.</typeparam>
	public static T GetRandomEnum<T>()
	{
		System.Array A = System.Enum.GetValues(typeof(T));
		T V = (T)A.GetValue(UnityEngine.Random.Range(0,A.Length));
		return V;
	}
}