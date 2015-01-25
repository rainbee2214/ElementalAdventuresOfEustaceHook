using UnityEngine;
using System.Collections;

public class FireballTravel : MonoBehaviour 
{
	public float speed;
	public int direction;

	void Start () 
	{
	
	}

	void FixedUpdate () 
	{
		transform.position = Vector3.MoveTowards(transform.position, 
		                                         new Vector3(1000 * direction, 
		            										 transform.position.y, 
		            										 transform.position.z), 
		                                         Time.deltaTime * speed);
	}
}
