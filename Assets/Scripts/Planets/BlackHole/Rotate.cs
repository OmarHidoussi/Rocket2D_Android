using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    #region Variable

    public float Speed;

    #endregion

    #region BuiltInMethods

    void Start()
    {
        
    }

    void Update()
    {
       transform.Rotate(Vector3.forward * Speed * Time.deltaTime); 
    }

    #endregion

    #region CustomRegion

    #endregion
}
