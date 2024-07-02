using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet_Affector : MonoBehaviour
{

    #region Variabes
    
    public float Timer;
    public SliderController controller;
    public GameObject ItemSlider;

    #endregion

    #region BuiltInMethods

    void Start()
    {
        controller = GameManager.Instance.controller;
        ItemSlider = GameManager.Instance.MagnetItemSlider;
    }

    void FixedUpdate()
    {
        if(!controller.StartCount_Magnet)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Collectable")
        { 
            other.gameObject.GetComponent<Coin>().InMagnet = true; 
        }
    }

    #endregion

    #region CustomMethods

    #endregion

}
