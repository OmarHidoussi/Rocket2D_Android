using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundController : MonoBehaviour
{

    #region Variables

    public GameObject[] splashes;
    public GameObject[] CosmicClouds;
    public float waitTime;
    
    private int index;

    #endregion

    #region CustomMethods 

    public void ChangeSplash()
    {
        splashes[index].SetActive(false);
        index = Random.Range(0,splashes.Length);
        splashes[index].SetActive(true);
    }

    #endregion

}
