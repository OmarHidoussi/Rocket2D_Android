using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PlanetHoldCounter : MonoBehaviour
{

    #region Variables

    public Rigidbody2D rb;

    [HideInInspector] public Canvas canvas;
    [HideInInspector] public Slider TimeSlider;

    public Color[] color;
    
    private Image image;
    private RocketMovement Rocket;
    private RocketController controller;

    #endregion

    #region BuiltInMethods

    void Start()
    {

        canvas = GetComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;

        TimeSlider = GetComponentInChildren<Slider>();
        image = GetComponentInChildren<Image>();

        controller = GameManager.Instance.Rocket.gameObject.GetComponent<RocketController>();   
        Rocket = GameManager.Instance.Rocket;

        TimeSlider.maxValue = controller.HoldWaitTime;
        TimeSlider.value = TimeSlider.maxValue;
    
    }

    void Update()
    {

        if(controller.interact && Rocket.connectedBody == rb)
        {
            TimeSlider.value = controller.HoldWaitTime;
        }

        if(!controller.interact)
        {
            image.color = Color.Lerp(image.color,color[1],5*Time.deltaTime);
        }
        /*else if(controller.interact && 
        Rocket.transform.position.y > Rocket.connectedBody.transform.position.y + 2.51f)
        {
            image.color = Color.Lerp(image.color,color[1],5*Time.deltaTime);
        }*/
        else
        {
            image.color = Color.Lerp(image.color,color[0],5*Time.deltaTime);
        }

    
    }

    #endregion

    #region CustomMethods

    #endregion

}
