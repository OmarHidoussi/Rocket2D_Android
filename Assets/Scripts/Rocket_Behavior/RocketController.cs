using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{

    #region Variables

    public bool Hold;
    public bool Release;
    public bool interact;

    public float WaitTime;
    public float HoldWaitTime;
    public float TimePunishment;
    public RocketMovement Rocket;

    private float restorHoldingTimer;

    #endregion

    #region BuiltInMethods

    void Start()
    {
        restorHoldingTimer = HoldWaitTime;

        Hold = false;
        Release = false;
        interact = true;
    }

    private void Update()
    {  
        
        if(Rocket.joint.connectedBody)
        {
            HoldWaitTime -= Time.deltaTime;
        }

        if(HoldWaitTime <= 0)
        {
            HoldWaitTime = restorHoldingTimer;
            BreakJoint();
        }

        if(interact)
        {
            Taptoplay();
        }
    }

    #endregion

    #region CustomMethods

    public void Taptoplay()
    {
        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Hold = true;
                Release = false;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Release = true;
                Hold = false;
                interact = false;
                
                HoldWaitTime = restorHoldingTimer;

                StartCoroutine(InputRestore(WaitTime));
            }
        }
    }

    void BreakJoint()
    {
        Rocket.Release();

        interact = false;
        Hold = false;

        StartCoroutine(InputRestore(TimePunishment));
    }

    IEnumerator InputRestore(float Timer)
    {
        yield return new WaitForSeconds(Timer);
        interact = true;
    }

    #endregion

}
