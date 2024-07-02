using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketGrappler : MonoBehaviour
{  

    #region Variables

    public LineRenderer lineRenderer;
    public Transform GrappleFrom;
    public float LineWidth;
    [HideInInspector] public Transform GrappleTo;

    #endregion

    #region BuiltInMethods

    private void Start() 
    {
        lineRenderer.enabled = false;
    }

    #endregion

    #region CustomMethods

    public void Grapple() 
    {
        lineRenderer.SetPosition(0,GrappleFrom.position);
        lineRenderer.SetPosition(1,GrappleTo.position);
        lineRenderer.enabled = true;
    } 

    #endregion

}
