using UnityEngine;
using System.Collections;

[RequireComponent(typeof(FireballController))]
public class MagicBoss : EnemyBase
{
    #region Public
    public Vector2 offset = new Vector2(-0.6f, 0.3f);
    public float attackDelay = 5f;
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

    [Range(-1,1)]
    public int direction = -1;
    public bool moveRight, moveLeft;
    public float speed = 10f;
    #endregion
    #region Private
    RaycastHit2D[] hits = new RaycastHit2D[2];
    bool playerInRange = false;
    bool playerInAttackRange = false;
    GameObject player;
    Vector2 currentDirection;
    float nextAttackTime;
    FireballController fireballs;
    Animator anim;
    Vector2 position;
    #endregion

    void Awake()
    {
        anim = GetComponent<Animator>();
        fireballs = GameController.controller.fireballController;
        Setup();
    }

    public void TakeDamage(int amount = -1)
    {
        Health = amount;
    }

    public void Move()
    {
        position = transform.position;
        if (moveRight)
        {
            position.x += speed *Time.deltaTime;
            anim.SetBool("WalkRight", true);
            anim.SetBool("WalkLeft", false);
        }
        else if (moveLeft)
        {
            position.x -= speed * Time.deltaTime;
            anim.SetBool("WalkLeft", true);
            anim.SetBool("WalkRight", false);
        }
        else
        {
            anim.SetBool("WalkRight", false);
            anim.SetBool("WalkLeft", false);
        }
        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TakeDamage();
        }
    }

    void FixedUpdate()
    {
        Move();
        if (fire) Fire();
        if (Health <= 0) Die();

        LookForPlayer();
        if (playerInAttackRange && Time.time > nextAttackTime) Fire();
    }

    public void Fire()
    {
        anim.SetTrigger("Attack");
        fire = false;
        Vector2 firePosition = new Vector2(transform.position.x + offset.x, transform.position.y + offset.y);
        fireballs.Fire(firePosition, direction);
        nextAttackTime = Time.time + attackDelay;
    }

	void Die()
	{
        gameObject.SetActive(false);
        //GameController.controller.bossController.RemoveResistance(ElementAttack.type);
	}

    void LookForPlayer()
    {
        playerInRange = false;

        int layerMask = 1 << LayerMask.NameToLayer("Player");

        hits[0] = Physics2D.Raycast(transform.position, Vector2.right, ViewRange, layerMask);
        Debug.DrawRay(transform.position, Vector2.right * ViewRange);
        hits[1] = Physics2D.Raycast(transform.position, -Vector2.right, ViewRange, layerMask);
        Debug.DrawRay(transform.position, -Vector2.right * ViewRange);

        for (int i = 0; i < hits.Length; i++)
        {
            if (playerInRange) break; // If already in range don't check other direction
            if (hits[i].collider != null)
            {
                if (hits[i].collider.CompareTag("Player"))
                {
                    player = hits[i].collider.gameObject;
                    playerInRange = true;
                    if (i == 0) currentDirection = Vector2.right;
                    else currentDirection = -Vector2.right;
                }
            }
        }

        if (playerInRange)
        {
            hits[0] = Physics2D.Raycast(transform.position, currentDirection, AttackRange, layerMask);
            Debug.DrawRay(transform.position, currentDirection * AttackRange, Color.red);

            if (hits[0].collider != null)
            {
                if (hits[0].collider.CompareTag("Player"))
                {
                    playerInAttackRange = true;
                }
                else playerInAttackRange = false;
            }
            else playerInAttackRange = false;
        }
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
