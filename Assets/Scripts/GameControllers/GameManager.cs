using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region ManagerInstance

    private static GameManager _instance;
    
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }

            return _instance;
        }
    }

    #endregion

    #region Variables

    public Score_TraveledDistance HighestDist;
    public CurrentHighestScore currentHighestScore;
    public GameEnded gameOver;

    public float CamYOffset = -4.5f;
    
    [HideInInspector] public RocketMovement Rocket;
    [HideInInspector] public Animator FadeInAnim;
    [HideInInspector] public bool OnGameEnd;
    [HideInInspector] public float Ypos;
    [HideInInspector] public float score;
    [HideInInspector] public bool Perfect;
    [HideInInspector] public bool Check;
    
    // GameSettings : any setting that will be saved while the game is playing

    [HideInInspector] public bool Vibrate;
    [HideInInspector] public int CollectedCoins;
    [HideInInspector] public int TotalCoins;
    [HideInInspector] public int SelectedSkin;


    public Animator Perfect_Anim;
    public GameObject SpeedItemSlider;
    public GameObject MagnetItemSlider;
    public GameObject CBreakerItemSlider;
    public SliderController controller;
    public GameObject[] Skin;

    private CameraFollow cam;
    private int highestScore;

    #endregion

    #region BuiltInMethods

    void Awake()
    {
        CollectedCoins = 0;
        _instance = this;
        
        Rocket = (RocketMovement)FindObjectOfType(typeof(RocketMovement));  
        FadeInAnim = GameObject.Find("FadeIn").GetComponent<Animator>();

        TotalCoins = PlayerPrefs.GetInt("CurrentCoins");

    }

    void Start() 
    {
        cam = Camera.main.GetComponent<CameraFollow>();
        
        Vibrate = true;
    }

    void FixedUpdate() 
    {
        Ypos = HighestDist.CurrentDistance;
    }

    void Update()
    {
        OnGameEnd = gameOver.GameOver;

        if(OnGameEnd)
        {
            SaveUpdates();
        }

        if(Check)
        {
            Perfect_Anim.SetBool("Perfect",Perfect);
        }
    
    }

    #endregion
    
    #region CustomMethods

    public void GameStart()
    {
        cam.YOffset = CamYOffset;
    }

    public void SaveUpdates()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        float score = data.Score;

        if(Ypos > score)
        {
            SaveSystem.SavePlayer(this);
        }
    }   

    #endregion

}