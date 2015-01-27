using UnityEngine;
using System.Collections;

[RequireComponent(typeof(FireballController))]
public class MagicBoss : EnemyBase
{
    #region Public
    public Vector2 offset = new Vector2(-0.6f, 0.3f);
	[Header("Initial Values")]
	public int startHealth,
			   startStrength,
			   startAttackValue;
	
	public float startAttackRange, 
				 startViewRange;
	
	[Range(0.0f, 1.0f)]
	public float resistanceMultiplier;
	[Range(1.0f, 2.0f)]
	public float weaknessMultiplier;

    public bool fire;
    #endregion
    #region Private
    FireballController fireballs;
    Animator anim;
    #endregion

    void Awake()
    {
        anim = GetComponent<Animator>();
        fireballs = GetComponent<FireballController>();
        Setup();
    }

    public void Move()
    {

    }

    void FixedUpdate()
    {
        Move();
        if (fire) Fire();
        if (Health <= 0) Die();
    }

    public void Fire()
    {
        anim.SetTrigger("Attack");
        fire = false;
        Vector2 firePosition = new Vector2(transform.position.x + offset.x, transform.position.y + offset.y);
        fireballs.Fire(firePosition);
    }

	void Die()
	{
        gameObject.SetActive(false);
        GameController.controller.bossController.RemoveResistance(ElementAttack.type);
	}

    void Setup()
    {
        // Setup health, strength
        Health = startHealth;
        Strength = startStrength;

        // Setup view range
        AttackRange = startAttackRange;
        ViewRange = startViewRange;

        // Setup elemental & attack values
        ElementStat setup;
        setup.type = Element.Magic;
        setup.value = startAttackValue;
        ElementAttack = setup;

        // Setup resistance & weakness
        BuffStat res;
        res.type = Element.Magic;
        res.value = resistanceMultiplier;
        Resistance = res;

        BuffStat weak;
        weak.type = Element.Fire;
        weak.value = weaknessMultiplier;
        Weakness = weak;
    }
}
