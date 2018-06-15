using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projektile : MonoBehaviour
{
    private bool dragging = false;
    private Rigidbody2D rbd2D;

    public float SpeedModifier;
    public float Boundaries;
    public GameObject target;
    public Camera MainCamera;
    public LineRenderer leftArmLineRenderer;
    public LineRenderer rightArmLineRenderer;
    
    void Start()
    {
        rbd2D = GetComponent<Rigidbody2D>();
        EnableLineRenderer();
    }
    void EnableLineRenderer()
    {
        leftArmLineRenderer.enabled = true;
        rightArmLineRenderer.enabled = true;
        leftArmLineRenderer.SetPosition(0, leftArmLineRenderer.gameObject.transform.position);
        rightArmLineRenderer.SetPosition(0, rightArmLineRenderer.gameObject.transform.position);
        leftArmLineRenderer.SetPosition(1, transform.position);
        rightArmLineRenderer.SetPosition(1, transform.position);
        
    }
    void DisableLineRenderer()
    {
        leftArmLineRenderer.enabled = false;
        rightArmLineRenderer.enabled = false;
    }
    void UpdateLineRenderer()
    {
        leftArmLineRenderer.SetPosition(1, transform.position);
        rightArmLineRenderer.SetPosition(1, transform.position);
    }


    void Update()
    {
        UpdateLineRenderer();
        if(dragging) UpdateBallPosition();


        if(rbd2D.velocity == new Vector2(0,0) && dragging == false || Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    private void UpdateBallPosition()
    {
        Vector3 tempV3 = MainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 distanceVector = new Vector3(tempV3.x - target.transform.position.x, tempV3.y - target.transform.position.y, 0);
        transform.position = target.transform.position + Vector3.ClampMagnitude(distanceVector, Boundaries);
    }

    void OnMouseDown()
    {
        dragging = true;
    }
     void OnMouseUp()
    {
        dragging = false;
        DisableLineRenderer();
        LaunchProjektil();
    }

    private void LaunchProjektil()
    {
        rbd2D.isKinematic = false;
        rbd2D.velocity = new Vector3(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y, 0) * SpeedModifier;
    }
    void Reload()
    {
        rbd2D.velocity = new Vector2(0, 0);
        rbd2D.angularVelocity = 0f;
        rbd2D.isKinematic = true;
        transform.position = target.transform.position;
        EnableLineRenderer();

    }
}