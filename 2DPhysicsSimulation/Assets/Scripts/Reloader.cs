using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reloader : MonoBehaviour {

    public Transform SpawnPosition;
    public GameObject Shot;
   
	// Use this for initialization
	void Start ()
    {
       
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            Shot.SetActive(false);
            Shot.transform.position = SpawnPosition.position;
            Shot.SetActive(true);
        }

	}
    
}
