using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_Coins : MonoBehaviour
{

    #region Variables
    
    public TextMeshProUGUI CoinsText;
    
    #endregion


    #region BuiltInMethods
    
    void Start()
    {
        CoinsText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        UpdateCoinsCounter();
    }

    #endregion

    #region CustomMethods

    void UpdateCoinsCounter() 
    {
        CoinsText.text = GameManager.Instance.CollectedCoins.ToString();
    }

    #endregion

}
