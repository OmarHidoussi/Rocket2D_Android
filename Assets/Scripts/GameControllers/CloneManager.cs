using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneManager : MonoBehaviour
{

    // <<< OLD_SYSTEM >>> \\

/*   */

/*
#region OLD_SYSTEM

    #region Variables

    public GameManager manager;
    public GameObject[] Planets; 
    public float DiffLevelFactor;
    public float MaxDiffLevel;
    public float frequency;
    public float FactorRange;
    public float YOffset;

    private RocketMovement Rocket;
    private Camera cam;
    private int PreviousIndex;
    private int CurrentIndex;
    private float LastRecord;
    private float Factor;

    #endregion

    #region BuiltInMethods

    void Awake()
    {
        PreviousIndex = Planets.Length + 1;
    }

    void Start()
    {
        manager = GameManager.Instance;
        cam = Camera.main;    
        Rocket = manager.Rocket; 
        
        LastRecord = Rocket.transform.position.y;
        Factor = Random.Range(0,FactorRange);
        
        float FacOfFactor = Random.Range(1,10);
        if(FacOfFactor > 5)
        {
            Factor *= -1;
        }
    }

    void FixedUpdate()
    {
        if(Rocket != null)
        {
            if(Rocket.transform.position.y >= LastRecord + frequency)
            {
                LastRecord = (LastRecord + frequency) + frequency;
                SponePlanet();
            }
        }
    }

    #endregion

    #region CustomMethods

    void SponePlanet()
    {
        int index = Random.Range(0,Planets.Length);
        CurrentIndex = index;

        if(CurrentIndex == PreviousIndex)
        {
            if(CurrentIndex <= Planets.Length - 1)
            {
                CurrentIndex = 0;
            }
            else
            {
                CurrentIndex += 1;
            }
        }

        PreviousIndex = CurrentIndex;

        Instantiate(Planets[CurrentIndex],new Vector3(Rocket.transform.position.x + Factor , cam.transform.position.y + YOffset ,Rocket.transform.position.z) ,Quaternion.identity);
    }

    public void IncreaseDifficulty()
    {
        if(frequency > MaxDiffLevel)
        {
            frequency -= DiffLevelFactor;
        }
    }

    #endregion

#endregion

*/

/*   */

    // <<< NEW_SYSTEM >>> \\


#region NEW_SYSTEM

    #region Variables

    public GameDifficulty gameDiff;

    public GameManager manager;
    public GameObject[] Planets; 
    public GameObject[] PlanetsGroup;
    public GameObject SolarSystems; 
    public GameObject Astroid;
    
    public bool astro;

    float PreviousSpone;

    public float TimeSpone;

    public float DiffLevelFactor = 0.2f;
    public float MaxDiffLevel = 6;
    public float frequency = 8;
    public float FactorRange = 2;
    public float YOffset = 20;
    public float SolarSystemYOffset = 60;

    private RocketMovement Rocket;
    private Camera cam;
    private CameraFollow camFol;
    
    private int DiffLevel;
    private int PreviousIndex;
    private int CurrentIndex;
    private float LastRecord;
    private float Factor;
    private bool SolarSystemAv;

    #endregion

    #region BuiltInMethods

    void Awake()
    {
        PreviousIndex = Planets.Length + 1;
    }

    void Start()
    {
        manager = GameManager.Instance;
        cam = Camera.main;   
        camFol = cam.GetComponent<CameraFollow>();
        Rocket = manager.Rocket; 
        
        DiffLevel = gameDiff.DiffLevel;


        LastRecord = Rocket.transform.position.y;
        Factor = Random.Range(0,FactorRange);
        
        float FacOfFactor = Random.Range(1,10);
        if(FacOfFactor > 5)
        {
            Factor *= -1;
        }

        SolarSystemAv = true;

        PreviousSpone = TimeSpone;
    }

    void FixedUpdate()
    {

        if(astro)
        {
            Astroids();
        }

        DiffLevel = gameDiff.DiffLevel;

        if(Rocket != null)
        {
            if(Rocket.transform.position.y >= LastRecord + frequency)
            {
                LastRecord = (LastRecord + frequency) + frequency;

                if(DiffLevel == 1)
                {
                    Level1();
                }
                else if(DiffLevel == 2)
                {
                    Level2();
                    SolarSystemAv = true;
                }
                else if(DiffLevel == 3)
                {
                    /*if(SolarSystemAv)
                    {*/
                        Astroids();
                    //}
                }
            }
        }
    }

    #endregion

    #region CustomMethods

    void Level1()
    {
        camFol.ZoomOutEvent = false;

        int index = Random.Range(0,Planets.Length);
        CurrentIndex = index;

        if(CurrentIndex == PreviousIndex)
        {
            if(CurrentIndex <= Planets.Length - 1)
            {
                CurrentIndex = 0;
            }
            else
            {
                CurrentIndex += 1;
            }
        }

        PreviousIndex = CurrentIndex;

        Instantiate(Planets[CurrentIndex],new Vector3(Rocket.transform.position.x , cam.transform.position.y + YOffset ,Rocket.transform.position.z) ,Quaternion.identity);
    }

    void Level2()
    {
        camFol.ZoomOutEvent = false;

        int index = Random.Range(0,PlanetsGroup.Length);
        CurrentIndex = index;

        if(CurrentIndex == PreviousIndex)
        {
            if(CurrentIndex <= PlanetsGroup.Length - 1)
            {
                CurrentIndex = 0;
            }
            else
            {
                CurrentIndex += 1;
            }
        }

        PreviousIndex = CurrentIndex;

        Instantiate(PlanetsGroup[CurrentIndex],new Vector3(Rocket.transform.position.x , 
        cam.transform.position.y + YOffset ,Rocket.transform.position.z) ,Quaternion.identity);
    }

    
    void Astroids()
    {
        camFol.ZoomOutEvent = true;

        TimeSpone -= Time.deltaTime * 60;

        if(TimeSpone <= 0)
        {
            Instantiate(Astroid,new Vector3(Rocket.transform.position.x , 
            cam.transform.position.y + YOffset + 8,Rocket.transform.position.z),Quaternion.identity);

            TimeSpone = PreviousSpone;  
        }
        
    }

    void Level3()
    {
        SolarSystemAv = false;

        /*int index = Random.Range(0,SolarSystems.Length);
        CurrentIndex = index;

        if(CurrentIndex == PreviousIndex)
        {
            if(CurrentIndex <= SolarSystems.Length - 1)
            {
                CurrentIndex = 0;
            }
            else
            {
                CurrentIndex += 1;
            }
        }

        PreviousIndex = CurrentIndex;

        Instantiate(SolarSystems[CurrentIndex],new Vector3(Rocket.transform.position.x + Factor , cam.transform.position.y + SolarSystemYOffset ,Rocket.transform.position.z) ,Quaternion.identity);
        */
        SolarSystems.transform.position = new Vector3(Rocket.transform.position.x + Factor , 
        cam.transform.position.y + SolarSystemYOffset ,Rocket.transform.position.z);
        SolarSystems.SetActive(true);
    }

    #endregion

#endregion


}
