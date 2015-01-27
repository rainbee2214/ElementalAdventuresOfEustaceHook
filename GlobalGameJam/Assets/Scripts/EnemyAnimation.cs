using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour {

	Animator anim;
	
	void Awake()
	{
		anim = GetComponent<Animator>();
	}
	
	public void Idle()
	{
		anim.SetBool("Attack", false);
		anim.SetBool("WalkLeft", false);
		anim.SetBool("WalkRight", false);
	}
	
	public void WalkLeft()
	{
		anim.SetBool("Attack", false);
		anim.SetBool("WalkLeft", true);
		anim.SetBool("WalkRight", false);
	}
	
	public void WalkRight()
	{
		anim.SetBool("Attack", false);
		anim.SetBool("WalkLeft", false);
		anim.SetBool("WalkRight", true);
	}

	public void Attack()
	{
		anim.SetBool("Attack", true);
	}


}
