using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArround : MonoBehaviour
{

    #region Variables

    public float RotSpeed;
    public Transform Target;

    #endregion

    #region BuiltInMethods
    
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.RotateAround(Target.transform.position ,Vector3.forward, RotSpeed * Time.deltaTime);
    }

    #endregion

    #region CustomMethods

    #endregion
}
