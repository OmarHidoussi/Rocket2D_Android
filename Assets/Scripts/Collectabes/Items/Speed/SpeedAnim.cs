using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAnim : MonoBehaviour
{

    #region Variables

    public GameObject[] speedElem; 
    public float UpdateIn;
    
    private float Timer;
    private bool update;
    
    int i = 0;

    #endregion

    #region BuiltInMethods

    void Start()
    {
        foreach (GameObject Element in speedElem)
        {
            Element.SetActive(false);
        }

        update = false;
    }

    void FixedUpdate()
    {
        Timer += Time.deltaTime;

        if(Timer > UpdateIn)
        {
            if(update)
            {
                foreach (GameObject Element in speedElem)
                {
                    Element.SetActive(false);
                }
            }

            speedElem[i].SetActive(true); 

            for (int j = 0 ; j < speedElem.Length ; j++)
            {
                if(speedElem[j].activeSelf == true)
                {
                    update = true;
                }
                else
                {
                    update = false;
                }
            }

            i += 1;

            if(i == speedElem.Length)     
            {
                foreach (GameObject Element in speedElem)
                {
                    Element.SetActive(false);
                }

                i = 0;
            }

            Timer = 0;
        }
    }

    #endregion

}
