using UnityEngine;
using System.Collections;

public class Fireball : Collectable 
{
	public float speed = 1f;
    public int direction = -1;
    public bool fire;

    Vector2 targetPosition;
    bool on;

    Animator anim;
    float resetTime;
    float resetDelay = 0.1f;
    bool reset;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

	public void Fire(Vector2 position, int parentDirection) 
	{
        direction = parentDirection;
        TurnOn(position);
        on = true;
        fire = false;
        switch(direction)
        {
            case 1: anim.SetTrigger("Right"); break;
            case -1: anim.SetTrigger("Left"); break;
            default: break;
        }
	}

    void Explode()
    {
        anim.SetTrigger("Explode");
        resetTime = Time.time + resetDelay;
        reset = true;
    }

    public override void Reset()
    {
        base.Reset();
        on = false;
    }
	void FixedUpdate () 
	{
        if (fire) Fire(transform.position, -1);
        if (on)
        {
            targetPosition.Set(1000f * direction, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        }

        if (reset && Time.time > resetTime) Reset();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Explode();      
            GameController.controller.TakeDamage();
        }
    }
}
