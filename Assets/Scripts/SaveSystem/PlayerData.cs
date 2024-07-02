using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{

    #region Variables

    public float Score = 0;
    public int Coins = 0;

    #endregion

    #region CustomMethods

    public PlayerData(GameManager player)
    {
        //Coins = player.CollectedCoins;
        
        Score = player.Ypos;        
    }

    #endregion

}
