using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_TraveledDistance : MonoBehaviour
{

    #region Variables

    public GameManager manager;
    public TextMeshProUGUI DistanceText;
    public int AddativeNumber;
    public int UpdateAfter;

    [HideInInspector] public int CurrentDistance;
    [HideInInspector] public float PreviousUpdate;
    [HideInInspector] public int Score;


    private RocketMovement Movement;
    private Transform Rocket;

    #endregion

    #region BuiltInMethods

    void Start()
    {
        DistanceText = GetComponent<TextMeshProUGUI>();
        Movement = manager.Rocket;  
        Rocket = Movement.transform;
     
        PreviousUpdate = (Mathf.Round(Rocket.position.y));
        CurrentDistance = 0;
    }

    void Update()
    {
        if((Mathf.Round(Rocket.transform.position.y)) > (PreviousUpdate + UpdateAfter))
        {
            CurrentDistance += AddativeNumber;
            DistanceText.text = CurrentDistance.ToString() + " Km";
            PreviousUpdate = (Mathf.Round(Rocket.position.y));
        }
    }

    #endregion

}
