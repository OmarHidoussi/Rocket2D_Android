using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RocketMovement : MonoBehaviour
{

    #region Variables

    public float Speed;
    public float MaxSpeed;
    public float TransTime;
    public float ColRadius;
    public float DistanceLerp;
    public float TriggerOffset;
    public float TimeToRelease;
    public float SpeedDiffLevelFactor;
    public float TransTimeDiffLevelFactor;

    public GameObject _Magnet;
    public GameObject _CBreaker;
    public SliderController S_controller;
    public GameObject PS_Release;

    [HideInInspector] public bool interact;
    [HideInInspector] public bool Speeditem;
    [HideInInspector] public bool InSolarSystem;
    [HideInInspector] public bool SpeedStartCount;
    [HideInInspector] public SpringJoint2D joint;
    [HideInInspector] public CircleCollider2D Col;
    [HideInInspector] public Rigidbody2D connectedBody;
    [HideInInspector] public RocketController controller;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public Camera cam;


    private RocketInfo info;

    float SpeedTimer;
    float PreviousSpeed;
    bool resetSpeed;
    //Rigidbody2D latestConnectedBody;

    #endregion
    
    #region BuiltInMethods

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<SpringJoint2D>();
        Col = GetComponent<CircleCollider2D>();
        controller = GetComponent<RocketController>();
        S_controller = GameManager.Instance.controller;

        cam = Camera.main;

        joint.connectedBody = null;
        connectedBody = null;
        interact = false;

        ColRadius = Col.radius;
        
        PreviousSpeed = Speed;

        SpeedStartCount = false;
        resetSpeed = false;
        Speeditem = false;
        InSolarSystem = false;
    }

    void FixedUpdate()
    {
        //Hundles the speed Item
        AddSpeed();

        if(!interact)
        {
            RocketDirection(cam.transform.rotation,TransTime);
        }

        rb.velocity = Speed * transform.TransformDirection(Vector3.up) * Time.deltaTime;

        if(resetSpeed)
            ResetSpeed();


        if (Input.GetButton("Jump") || controller.Hold)
        {
            if (connectedBody != null)
            {
                if(transform.position.y < connectedBody.transform.position.y + 2.5f)
                {
                    Hold();
                    //latestConnectedBody = connectedBody;
                }
            }
        }
        else
        {
            /*if(controller.Release || latestConnectedBody != null)
            {
                Instantiate(PS_Release,latestConnectedBody.transform.position,Quaternion.identity);
                latestConnectedBody = null;
            }*/
            Release();
        }

    }

    #endregion

    #region CustomMethods

    public void Hold()
    {

        Joint_Config(connectedBody,1.45f,0,false);

        joint.enabled = true;
        GameManager.Instance.Check = false;
    }

    public void Release()
    {
        joint.connectedBody = null;
        joint.enabled = false;
        interact = false;
        GameManager.Instance.Check = true;

        Speed = PreviousSpeed;
    }

    public void RocketDirection(Quaternion wantedRotation,float transitionSpeed)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, wantedRotation, transitionSpeed * Time.deltaTime);
    }

    public void IncreaseDifficulty()
    {
        if(Speed < MaxSpeed - 1000)
        {
            Speed += SpeedDiffLevelFactor;
            
            if(!interact)
                PreviousSpeed = Speed;

            if(TransTime < 2.4f)
            {
                TransTime += TransTimeDiffLevelFactor;
            }
        }
    }

    public void AddSpeed()
    {
        SpeedTimer = S_controller.SpeedTimer;

        if(SpeedStartCount)
        {
            Speed = MaxSpeed;
            
            if(SpeedTimer <= 0.04f)
            {
                DecreaseSpeed();
            }
        }
    }

    public void DecreaseSpeed()
    {
        resetSpeed = true;
        SpeedStartCount = false;
    }

    void ResetSpeed()
    {
        Speed = Mathf.Lerp(Speed ,PreviousSpeed ,TransTime * Time.deltaTime);

        if(Speed <= PreviousSpeed + 0.5f)
        {
            Speed = PreviousSpeed;
            resetSpeed = false;
        }
    }
    
    public void Joint_Config(Rigidbody2D body,float distance,float wanteddist,bool GravityPull)
    {
        joint.connectedBody = body;
        joint.distance = distance;
        
        interact = true;

        if(GravityPull)
        {
            distance = Mathf.Lerp(distance ,wanteddist ,DistanceLerp * Time.deltaTime); 
        }

        if(!joint.enabled)
        {
            joint.enabled = true;
        }
    }

    #endregion

}