using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrentHighestScore : MonoBehaviour
{

    #region Variables

    public float highestScore;
    public TextMeshProUGUI ScoreTXT;

    #endregion

    #region BuiltInMethods

    private void Start() 
    {
        ScoreTXT = GetComponentInChildren<TextMeshProUGUI>();
        LoadPlayer();
    }

    #endregion

    #region CustomMethods

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        float score = data.Score;
        highestScore = score;

        ScoreTXT.text = highestScore.ToString("0");
    }

    #endregion

}
