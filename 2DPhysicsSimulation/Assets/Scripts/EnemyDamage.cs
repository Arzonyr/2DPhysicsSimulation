using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {


    public int health = 3;
    public Sprite damagedSprite;
    public float damageImpactSpeed;
    public GameObject Enemy;
    private bool IsDead = false;
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
        if (health <= 1)
            spriteRenderer.sprite = damagedSprite;

        if (health <= 0 && IsDead == false)
            StartCoroutine(Kill());
	}
    IEnumerator Kill()
    {
        IsDead = true;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1);
        Destroy(Enemy);
       
       
       // Destroy(Enemy);
    }
}
