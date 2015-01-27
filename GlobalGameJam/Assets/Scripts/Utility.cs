using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Element
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
	public Element type;
	public int value;
}

/// <summary>
/// Buff stat, used for resistance/weakness type and value
/// </summary>
public struct BuffStat
{
	public Element type;
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