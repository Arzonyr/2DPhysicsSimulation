using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projektile : MonoBehaviour
{

    public float maxStretch = 3.0f;
    public LineRenderer catapultLineFront;
    public LineRenderer catapultLineBack;
    public GameObject Shot;
    public GameObject catapult;
    public Transform spawnPositon;
    public float reloadTime;
    public float resetSpeed = 0.025f;
    public GameObject projektile;
    private float resetSpeedSqr;
    private Rigidbody2D shotRgdb;
    private SpringJoint2D spring;
    private Transform catapultTrans;
    private Ray rayToMouse;
    private Ray leftCatapultToProjectile;
    private float maxStretchSqr;
    private float circleRadius;
    private bool clickedOn;
    private  Vector2 prevVelocity;
    private Rigidbody2D rigidbody2d;
    private CircleCollider2D circle;
    private Vector2 prevShotVelocity;


    private Transform lastposition = null;
    bool needToReload = false;

   
    void OnEnable()
    {
        
        spring = GetComponent<SpringJoint2D>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
       
        catapultTrans = spring.connectedBody.transform;
    }
    

    void Start()
    {
       
        resetSpeedSqr = resetSpeed * resetSpeed;
        LineRendererSetup();
        rayToMouse = new Ray(catapultTrans.position, Vector3.zero);
        leftCatapultToProjectile = new Ray(catapultLineFront.transform.position, Vector3.zero);
        maxStretchSqr = maxStretch * maxStretch;
        circleRadius = circle.radius;
    }
    void Update()
    {
        if (clickedOn)
            Dragging();

        if (spring != null)
        {
            if (!rigidbody2d.isKinematic && prevVelocity.sqrMagnitude > rigidbody2d.velocity.sqrMagnitude)
            {
              //  if (neverdone)
                {
                    spring.enabled = !spring.enabled;
                    catapultLineBack.enabled = !catapultLineBack.enabled;
                    catapultLineFront.enabled = !catapultLineFront.enabled;
                    needToReload = false;
                }
                
                Destroy(spring);
                rigidbody2d.velocity = prevVelocity;
                needToReload = true;
               // StartCoroutine(Reload());
               // if ( rigidbody2d.velocity.sqrMagnitude < resetSpeedSqr)
                

               
              


                
            }
            if (!clickedOn)
                prevVelocity = rigidbody2d.velocity;

            LineRendererUpdate();
        }
        else
        {
            catapultLineFront.enabled = false;
            catapultLineBack.enabled = false;
        }
        
        if (needToReload && rigidbody2d.velocity == new Vector2(0,0))
        {
            StartCoroutine(Reload());
        }
        
    }

    void LineRendererSetup()
    {
        catapultLineFront.SetPosition(0, catapultLineFront.transform.position);
        catapultLineBack.SetPosition(0, catapultLineBack.transform.position);

        catapultLineFront.sortingLayerName = "Default";
        catapultLineBack.sortingLayerName = "Default";

        catapultLineFront.sortingOrder = 3;
        catapultLineBack.sortingOrder = 1;
    }

    void OnMouseDown()
    {
        spring.enabled = false;
        clickedOn = true;
    }

    void OnMouseUp()
    {
        spring.enabled = true;
        rigidbody2d.isKinematic = false;
        clickedOn = false;
    }

    void Dragging()
    {
        Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 catapultToMouse = mouseWorldPoint - catapultTrans.position;
        if (catapultToMouse.sqrMagnitude > maxStretchSqr)
        {
            rayToMouse.direction = catapultToMouse;
            mouseWorldPoint = rayToMouse.GetPoint(maxStretch);
        }
        mouseWorldPoint.z = 0f;
        transform.position = mouseWorldPoint;
    }

    void LineRendererUpdate()
    {
        Vector2 catapultToProjectile = transform.position - catapultLineFront.transform.position;
        leftCatapultToProjectile.direction = catapultToProjectile;
        Vector3 holdPoint = leftCatapultToProjectile.GetPoint(catapultToProjectile.magnitude + circleRadius);
        catapultLineFront.SetPosition(1, holdPoint);
        catapultLineBack.SetPosition(1, holdPoint);
    }
     IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        Shot.SetActive(false);
        Shot.transform.position = spawnPositon.position;
        shotRgdb = GetComponent<Rigidbody2D>();
        shotRgdb.isKinematic = true;
        SpringJoint2D sj = Shot.AddComponent(typeof(SpringJoint2D)) as SpringJoint2D;
        spring = GetComponent<SpringJoint2D>();
        spring.connectedBody = catapult.GetComponent<Rigidbody2D>();
        spring.autoConfigureDistance = false;
        spring.distance = 1f;
        spring.frequency = 5f;
        catapultLineBack.enabled = true;
        catapultLineFront.enabled = true;
        Shot.SetActive(true);
        needToReload = false;

    }
    
}