using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resetter : MonoBehaviour
{
    public Rigidbody2D projectile;
    public GameObject shot;
    public Transform spawnPoint;
        

    

    void Start()
    {
       
        
    }

    void Update()
    {
        
       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.GetComponent<Rigidbody2D>() == projectile)
        {
            projectile.velocity = new Vector2(0, 0);
            projectile.transform.position = spawnPoint.position;
        }
    }

   
}