using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentCoins : MonoBehaviour
{

    #region Variables
    
    public int CurrentCollectedCoins ;
    public TextMeshProUGUI CoinsTXT;
    
    #endregion

    #region BuiltInMethods

    void Start()
    {
        CoinsTXT = GetComponentInChildren<TextMeshProUGUI>();
        LoadPlayer();
    }

    #endregion

    #region CustomMethods

    void LoadPlayer()
    {
/* 
        PlayerData data = SaveSystem.LoadPlayer();
        CurrentCollectedCoins = data.Coins;
        CurrentCollectedCoins.ToString("0")
*/

        CoinsTXT.text = PlayerPrefs.GetInt("CurrentCoins").ToString();
    }

    #endregion
     
}
