using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnded : MonoBehaviour
{

    #region Variables

    public bool GameOver; 
    Animator anim;

    #endregion

    #region BuiltInMethods

    void Start()
    {
        GameOver = false;
        anim = GetComponent<Animator>();   
    }

    void Update()
    {
        if(anim.enabled)
        {
            GameOver = true;
        }
    }

    public void SaveChanges()
    {

        //float _TotalCoins = GameManager.Instance.TotalCoins;
        int _CollectedCoins = GameManager.Instance.CollectedCoins;

        int Coins = PlayerPrefs.GetInt("CurrentCoins") + _CollectedCoins;
        PlayerPrefs.SetInt("CurrentCoins",Coins);

        PlayerPrefs.SetInt("SelectedSkin",GameManager.Instance.SelectedSkin);

    }

    #endregion
    
}
