using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecorder : MonoBehaviour
{

    #region Variables

    #endregion

    #region BuiltInMethods

    void Start()
    {
        
    }

    void Update()
    {
    
    }

    #endregion

    #region CustomMethods

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Sensor")
        {
            GameManager.Instance.Perfect = true;

        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Sensor")
        {
            GameManager.Instance.Perfect = false;
        }
    }

    #endregion

}
