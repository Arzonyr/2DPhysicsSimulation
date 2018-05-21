using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {


    public int health = 2;
    public Sprite damagedSprite;
    public float damageImpactSpeed;
    public GameObject Enemy;

    private int currentHealth;
    private float damageImpactSpeedSqr;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = health;
        damageImpactSpeedSqr = damageImpactSpeed * damageImpactSpeed;
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.collider.tag != "Damager")
            return;
        if (collision.relativeVelocity.sqrMagnitude < damageImpactSpeedSqr)
            return;

        health--;
        if (health <= 0)
            Kill();
	}
    void Kill()
    {
        Destroy(Enemy);
    }
}
