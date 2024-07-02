using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine;

public class RocketThrusters : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{

    #region Variables

    public GameObject wantedDirection;
    public UnityEvent HoldEvent;
    public float SlidingSpeed;

    private bool HoldButton;

    #endregion

    #region BuiltInMethods

    void Start()
    {
        HoldButton = false;
    }

    void FixedUpdate()
    {
        if(HoldButton)
        {
            ChangeDirection();
        }
    }

    #endregion

    #region CustomMethods

    public void OnPointerDown(PointerEventData eventdata)
    {
        HoldButton = true;
    }

    public void OnPointerUp(PointerEventData eventdata)
    {
        HoldButton = false;
    }

    public void ChangeDirection()
    {
        GameManager.Instance.Rocket.RocketDirection(wantedDirection.transform.rotation ,SlidingSpeed);
    }

    #endregion 

}
