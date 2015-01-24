using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class RangeWeapon : MonoBehaviour {

	#region Propertie
	
	ElementStat damage;
	public ElementStat Damage
	{
		get { return damage; }
		set { damage = value; }
	}

	#endregion

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if( collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy" )
		{
			collision.gameObject.GetComponent<EnemyBase>().TakeDamage(damage);
		}
	}

	public void Fire() //maybe take some vector for initial fire condition, and a force for a direction.
	{
		//Do fire logic here to shoot this weapon.
	}
}
