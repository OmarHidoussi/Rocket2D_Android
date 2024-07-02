using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicBreaker_Affector : MonoBehaviour
{

    #region Variables

    private SliderController controller;
    [HideInInspector] public GameObject ItemSlider;

    #endregion

    #region BuiltInMethods

    void Start()
    {
        controller = GameManager.Instance.controller;
        ItemSlider = GameManager.Instance.CBreakerItemSlider;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Sensor")
        {
            controller.StartCount_CBreaker = true;
            GameManager.Instance.Rocket._CBreaker.SetActive(true);

            OnUpdateGameUI();

            controller.itemsSlider[2].gameObject.SetActive(true);
            controller.C_BreakerTimer = controller.CBreakerresetTimer;
            
            Destroy(gameObject);
        }
    }

    #endregion

    #region CustomMethods

    void OnUpdateGameUI()
    {
        ItemSlider.SetActive(true);
    }

    #endregion

}
