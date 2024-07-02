using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    #region Variables

    private float length, startpos;
    private Camera cam;
    public float parallaxEffect;

    #endregion

    #region BuiltInMethods

    void Start()
    {
        cam = Camera.main;
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void FixedUpdate()
    {
        float temp = (cam.transform.position.y * (1 - parallaxEffect));
        float dist = (cam.transform.position.y * parallaxEffect);

        transform.position = new Vector3(transform.position.x, startpos + dist, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;

    }

    #endregion
    
}
