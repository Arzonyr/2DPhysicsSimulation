using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public Rigidbody2D shotRgbd;
    public Transform TeleportTo;
    // Use this for initialization
    void Start()
    {

    }
   

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward);

    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>() == shotRgbd)
        {
            shotRgbd.transform.position = TeleportTo.position;
        }
    }


}
