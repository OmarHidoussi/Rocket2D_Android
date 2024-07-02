using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class SolarSystem : MonoBehaviour
{

    #region Variables

    public RocketController controller;
    public GameDifficulty gameDiff;
    public CircleCollider2D Col;
    public Rigidbody2D rb;
    public float GravityPullRadius;

 
    private CloneManager Clone;
    private RocketMovement Rocket;
    private CameraFollow cam;
    private float ResetHoldTime;

    #endregion

    #region BuiltInMethods

    void Start()
    {
        Clone = GetComponentInChildren<CloneManager>();
        Col = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        
        Rocket = GameManager.Instance.Rocket;

        cam = Camera.main.GetComponent<CameraFollow>();

        ResetHoldTime = controller.HoldWaitTime;

    }


    void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Rocket")
        {
            controller.HoldWaitTime = 20;
            float Distance = Vector3.Distance(transform.position,Rocket.transform.position);

            cam.ZoomOutEvent = true;

            if(Distance < GravityPullRadius)
            {
                if(!Rocket.controller.Hold)
                {
                    Rocket.InSolarSystem = true;


                    Rocket.connectedBody = rb;

                    //Rocket.Hold();

                    Rocket.Joint_Config(rb,GravityPullRadius,1.45f,true);

                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Rocket")
        {
            controller.HoldWaitTime = ResetHoldTime;

            cam.ZoomOutEvent = false;

            Rocket.InSolarSystem = false;

            int i = Random.Range(1,3);
            gameDiff.DiffLevel = i;

        }
    }

    #endregion

    #region CustomMethods

    #endregion

}
