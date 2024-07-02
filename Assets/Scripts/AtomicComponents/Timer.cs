using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{

    #region Variables

    public float RunEvery = 10;
    public bool RunOnAwake = false;
    public bool loop = true;
    public UnityEvent OnTimeEnd;

    #endregion

    #region BuiltInMethods

    private void OnEnable() 
    {
        if(RunOnAwake)
        {
            Invoke("Execute",0);   
        }

        if(loop)
        {
            InvokeRepeating("Execute",RunEvery,RunEvery);
        }
        else
        {
            Invoke("Execute",RunEvery);
        }
    }

    #endregion

    #region CustomMethods

    public void Execute()
    {
        OnTimeEnd.Invoke();
    }

    #endregion
}
