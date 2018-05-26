using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankDamage : MonoBehaviour {
    public int health = 20;
    public Sprite damagedSprite;
    public float damageImpactSpeed;
    public GameObject Plank;

    private int currentHealth;
    private float damageImpactSpeedSqr;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = health;
        damageImpactSpeedSqr = damageImpactSpeed * damageImpactSpeed;
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Damager")
            return;
        if (collision.relativeVelocity.sqrMagnitude < damageImpactSpeedSqr)
            return;
       
        health--;
        if (health <= 5)
            spriteRenderer.sprite = damagedSprite;
        if (health <= 0)
            Kill();
    }
    void Kill()
    {
        Destroy(Plank);
    }
}
