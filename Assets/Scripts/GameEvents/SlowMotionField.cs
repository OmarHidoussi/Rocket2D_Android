using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionField : MonoBehaviour
{
    
    #region Variables

    [HideInInspector] public TimeManager timeManager;
    [HideInInspector] public CameraFollow cam;

    #endregion

    #region BuiltInMethods

    void Start()
    {
        timeManager = GameManager.Instance.GetComponent<TimeManager>();
        //cam = camera.main.GetComponent<CameraFollow>();
    }

    #endregion

    #region CustomMethods

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Rocket")
        {
            
        }
    }

    #endregion


}
