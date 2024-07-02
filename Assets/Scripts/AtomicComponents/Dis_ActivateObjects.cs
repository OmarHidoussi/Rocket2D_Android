using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dis_ActivateObjects : MonoBehaviour
{

    #region Variables

    public GameObject[] ActivateObjects;
    public GameObject[] DisactivateObjects;

    #endregion

    #region BuiltInMethods

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region CustomMethods

    public void OnActivate()
    {
        for(int i=0;i<ActivateObjects.Length;i++)
        {
            ActivateObjects[i].SetActive(true);   
        }
    }

    public void OnDisactivate()
    {
        for(int i=0;i<DisactivateObjects.Length;i++)
        {
            DisactivateObjects[i].SetActive(false);   
        }
    }


    #endregion

}
