using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyComponent : MonoBehaviour
{

    #region Variables

    RocketMovement Rocket;

    public bool NotPlanet;

    #endregion

    #region BuiltInMethods
    
    private void Start()
    {
        Rocket = (RocketMovement)FindObjectOfType(typeof(RocketMovement));       
    }

    #endregion

    #region CustomMethods

    public void destroy()
    {
        if(Rocket)
        {
            if(Rocket.gameObject.transform.position.y > transform.position.y + 20)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }

        if(NotPlanet)
        {
            Destroy(gameObject);
        }
    }   
    
    #endregion

}
