using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{

    #region Variables

    public float Yoffset;
    public float rotationSpeed;

    private float Factor;

    #endregion

    #region BuiltInMethods

    void Start() 
    {
        //rotationSpeed = Random.Range(30,140);
       
        Factor = Random.Range(1,10);

        if(Factor > 7)
        {
            rotationSpeed *= -1;
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    #endregion

}
