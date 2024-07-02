using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class SpeedItem : MonoBehaviour
{

    #region Variables

    public float CallAfter;
    public GameObject ItemSlider;
    public SliderController controller;

    #endregion

    #region BuiltInMethods

    void Awake()
    {
        ItemSlider = GameManager.Instance.SpeedItemSlider;
        controller = GameManager.Instance.controller;
        CallAfter = controller.SpeedTimer;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Sensor")
        {
            controller.SpeedTimer = controller.SpeedresetTimer;

            GameManager.Instance.Rocket.SpeedStartCount = true;
            controller.StartCount_Speed = true;

            OnUpdateGameUI();

        }
    }

    void OnUpdateGameUI()
    {        
        ItemSlider.SetActive(true);
    }

    #endregion

}