using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStar : MonoBehaviour
{
    
    #region Variables

    public float speed;
    public Material[] mat;

    private TrailRenderer Trail;
    private int index;

    #endregion

    #region BuiltInMethods

    private void Start()
    {
        Trail = GetComponent<TrailRenderer>();
        index = Random.Range(0,mat.Length);
        Trail.sharedMaterial = mat[index];
    }

    void Update()
    {
        transform.Translate(transform.TransformDirection(transform.up) * speed * Time.deltaTime);    
    }

    #endregion

}