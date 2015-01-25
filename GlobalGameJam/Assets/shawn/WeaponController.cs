using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponController : MonoBehaviour 
{
	List<GameObject> weapons;
	public int numberOfWeapons = 25;
	int weaponIndex;
	Vector2 outOfView = new Vector2(100f, 100f);

	
	void Awake () 
	{
		weaponIndex = 0;
		WeaponSetup();
	}

	void WeaponSetup()
	{
		//load prefab
		//GameObject bullet = Resources.Load ("", typeof(GameObject)) as GameObject;
		
//		weapons = new List<GameObject> ();
//		for(int i=0; i< poolSize;i++)
//		{
//			weapons.Add( Instantiate(bullet, outOfView, Quaternion.identity) as GameObject);
//			weapons[i].transform.parent = transform;
//			weapons[i].name = "Bullet" + i;
//			weapons[i].SetActive(false);
//		}
	}

	void FixedUpdate () 
	{
		
	}

	public void Fire(Vector2 initialPosition, Vector2 force)
	{
		//set position of weapons[index] to initialPosition.
		//at the force to velocity of that weapon to fire it
		weapons [weaponIndex].transform.position = initialPosition;
		weapons [weaponIndex].SetActive (true);
		weapons [weaponIndex].rigidbody.AddForce (force);

		//increment index
		//index = (++index)%numberOfWeapons;
	}

}
