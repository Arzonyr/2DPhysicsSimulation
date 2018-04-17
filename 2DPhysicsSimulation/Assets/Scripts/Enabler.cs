using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabler : MonoBehaviour {

    public GameObject Shot;
    public GameObject catapult;
    public Transform spawnPositon;
    public LineRenderer catapultFront;
    public LineRenderer catapultBack;
    private Rigidbody2D shotRgdb;
    private SpringJoint2D spring;
    bool neverdone = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	
    void Update()
    {
        if (neverdone&&Input.GetKeyDown(KeyCode.K))
        {
            Shot.SetActive(false);
            Shot.transform.position = spawnPositon.position;
            shotRgdb = GetComponent<Rigidbody2D>();
            shotRgdb.isKinematic = true;
           // SpringJoint2D sj = Shot.AddComponent(typeof(SpringJoint2D)) as SpringJoint2D;
            spring = GetComponent<SpringJoint2D>();
            spring.connectedBody = catapult.GetComponent<Rigidbody2D>();
            spring.autoConfigureDistance = false;
            spring.distance = 1f;
            spring.frequency = 5f;
            catapultBack.enabled = true;
            catapultFront.enabled = true;
            Shot.SetActive(true);
            neverdone = false;
        }
    }
}
