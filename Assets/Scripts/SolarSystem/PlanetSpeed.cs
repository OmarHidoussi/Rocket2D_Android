using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlanetSpeed : MonoBehaviour
{
    
    #region Variables

    public float speed;
    
    private Rigidbody2D rb;    

    #endregion

    #region BuiltInMethods

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = (transform.TransformDirection(Vector3.up) * speed * Time.deltaTime);
    }

    #endregion

    #region CustomMethods

    #endregion

}
