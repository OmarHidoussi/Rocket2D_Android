using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficulty : MonoBehaviour
{

    #region Variables

    [Range(1,3)]
    public int DiffLevel;
    public int BegDiff;
    public int MaxDiffLevel;

    #endregion
    
    #region BuiltInMethods

    void Start()
    {
        DiffLevel = BegDiff;
    }
    
    #endregion

    #region CustomMethods

    public void IncreaseDiff()
    {
        if(DiffLevel < MaxDiffLevel)
        {
            DiffLevel += 1;
        }
    }

    #endregion

}