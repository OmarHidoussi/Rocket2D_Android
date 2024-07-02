using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    
    #region Variables

    public GameObject[] ActivateObject;
    public GameObject[] DisactivateObject;
    public GameObject TapToPlayBTN;


    private float timer = 1.5f;
    private bool disable;
    
    #endregion

    #region CustomMethods

    public void startGame()
    {

        GameManager.Instance.GameStart();

        for (int i=0;i<ActivateObject.Length;i++)
        {
            ActivateObject[i].SetActive(true);   
        }
        
        for (int i=0;i<DisactivateObject.Length;i++)
        {
            DisactivateObject[i].SetActive(false);   
        }

        disable = true;
    }

    void Update()
    {
        if(disable)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                TapToPlayBTN.SetActive(false);
            }
        }
    }

    #endregion

}
