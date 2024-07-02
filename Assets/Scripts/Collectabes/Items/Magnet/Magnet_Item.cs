using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet_Item : MonoBehaviour
{

    #region Variables
    
    private SliderController controller;
    public GameObject ItemSlider;

    #endregion

    #region BuiltInMethods

    void Start() 
    {
        controller = GameManager.Instance.controller;
        ItemSlider = GameManager.Instance.MagnetItemSlider;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Sensor")
        {
            controller.StartCount_Magnet = true;
            GameManager.Instance.Rocket._Magnet.SetActive(true);

            OnUpdateGameUI();

            controller.itemsSlider[1].gameObject.SetActive(true);
            controller.MagnetTimer = controller.MagnetresetTimer;
            
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
