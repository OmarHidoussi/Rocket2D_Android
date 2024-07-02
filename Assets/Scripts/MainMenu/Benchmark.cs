using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Benchmark : MonoBehaviour
{

    #region Variables

    public TextMeshProUGUI FPSText;
    public float PreviousRefresh;
    public float RefreshAfter = 2f;

    #endregion

    #region BuiltInMethods

    void Start()
    {
        PreviousRefresh = RefreshAfter;
        FPSText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Application.targetFrameRate = 61;

        RefreshAfter -= Time.deltaTime;

        if(RefreshAfter <= 0)
        {
            FPSText.text = "FPS : " + (int) (1 / Time.deltaTime);
            RefreshAfter = PreviousRefresh;
        }
    }

    #endregion
}
