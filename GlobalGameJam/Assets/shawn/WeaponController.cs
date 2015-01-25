using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponController : MonoBehaviour 
{
	List<GameObject> weapons;
	public int numberOfWeapons = 25;
	int weaponIndex;
	Vector2 outOfView = new Vector2(100f, 100f);
	public Animator anim;

	
	void Awake () 
	{
		weaponIndex = 0;
		WeaponSetup();
		anim = GetComponent<Animator>();
	}

	void WeaponSetup()
	{
		GameObject bullet = Resources.Load ("Prefabs/FireBall", typeof(GameObject)) as GameObject;
		
		weapons = new List<GameObject> ();
		for(int i=0; i< numberOfWeapons;i++)
		{
			weapons.Add( Instantiate(bullet, outOfView, Quaternion.identity) as GameObject);
			weapons[i].transform.parent = transform;
			weapons[i].name = "Bullet" + i;
			weapons[i].SetActive(false);
		}
	}

	void FixedUpdate () 
	{
	}

	public void Fire(Vector2 initialPosition, Vector2 force, Vector2 direction)
	{
		//set position of weapons[index] to initialPosition. 
		//at the force to velocity of that weapon to fire it
		Animator weaponAnimator = weapons[weaponIndex].gameObject.GetComponent<Animator>();
		if(direction == Vector2.right) 
		{
			weaponAnimator.SetBool("FireRight", true);
			weaponAnimator.SetBool("FireLeft", false);
			Debug.Log ("firing right");
		}
		else
		{
			Debug.Log ("firing left");
			weaponAnimator.SetBool("FireRight", false);
			weaponAnimator.SetBool("FireLeft", true);
		}
		weapons [weaponIndex].transform.position = initialPosition;
		weapons [weaponIndex].SetActive (true);
		//weapons [weaponIndex].rigidbody.AddForce (force);

		//increment index
		weaponIndex = (++weaponIndex)%numberOfWeapons;
	}

}
