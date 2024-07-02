using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{

    #region Variables

    public float SpeedTimer;
    public float MagnetTimer;
    public float C_BreakerTimer;
    public ItemsSlider[] itemsSlider;

    [HideInInspector] public bool StartCount_Speed;
    [HideInInspector] public bool StartCount_Magnet;
    [HideInInspector] public bool StartCount_CBreaker;
    [HideInInspector] public float SpeedresetTimer;
    [HideInInspector] public float MagnetresetTimer;
    [HideInInspector] public float CBreakerresetTimer;


    #endregion

    #region BuiltInMethods

    void Start() 
    {
        StartCount_Speed = false;
        StartCount_Magnet = false;
        StartCount_CBreaker = false;

        SpeedTimer *= Time.timeScale;
        MagnetTimer *= Time.timeScale;
        C_BreakerTimer *= Time.timeScale;

        SpeedresetTimer = SpeedTimer;    
        MagnetresetTimer = MagnetTimer;
        CBreakerresetTimer = C_BreakerTimer;

        itemsSlider[0].slider.maxValue = SpeedTimer;
        itemsSlider[1].slider.maxValue = MagnetTimer;
        itemsSlider[2].slider.maxValue = C_BreakerTimer;
    }

    void FixedUpdate()
    {

        itemsSlider[0].slider.value = SpeedTimer;
        itemsSlider[1].slider.value = MagnetTimer;
        itemsSlider[2].slider.value = C_BreakerTimer;

        if(StartCount_Speed)
        {
            ItemTimerSpeed(itemsSlider[0].slider);
        }

        if(StartCount_Magnet)
        {
            ItemTimerMagnet(itemsSlider[1].slider);
        }

        if(StartCount_CBreaker)
        {
            ItemTimerCosmicBreaker(itemsSlider[2].slider);
        }
        
    }

    #endregion

    #region CustomMethods

    public void ItemTimerSpeed(Slider slider)
    {
        SpeedTimer -= Time.deltaTime;

        if(SpeedTimer <= 0)
        {
            StartCount_Speed = false;
            SpeedTimer = SpeedresetTimer;
            
            itemsSlider[0].slider.gameObject.SetActive(false);
        }
    } 

    public void ItemTimerMagnet(Slider slider)
    {
        MagnetTimer -= Time.deltaTime;

        if(MagnetTimer <= 0)
        {
            StartCount_Magnet = false;
            MagnetTimer = MagnetresetTimer;

            itemsSlider[1].slider.gameObject.SetActive(false);
        }
    } 

    public void ItemTimerCosmicBreaker(Slider slider)
    {
        C_BreakerTimer -= Time.deltaTime;

        if(C_BreakerTimer <= 0)
        {
            StartCount_CBreaker = false;
            C_BreakerTimer = CBreakerresetTimer;

            itemsSlider[2].slider.gameObject.SetActive(false);
        }
    } 

    #endregion
}
