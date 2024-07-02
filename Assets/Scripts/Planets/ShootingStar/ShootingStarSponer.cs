using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStarSponer : MonoBehaviour
{
    
    #region Variables

    public GameObject ShootingStar;

    #endregion

    #region CustomMethods

    public void Spone()
    {
        float randFactorX = Random.Range(1,2);
        float randFactorY = Random.Range(1,2);
        float randFactor = Random.Range(1,4);

        if(randFactor > 2)
        {
            Instantiate(ShootingStar,new Vector3(transform.position.x + randFactorX,transform.position.y + randFactorY,0) ,transform.rotation);
        }
        else
        {
            Instantiate(ShootingStar,new Vector3(transform.position.x - randFactorX,transform.position.y - randFactorY,0) ,transform.rotation);
        }
    }

    #endregion

}
