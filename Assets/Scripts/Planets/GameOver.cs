using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    #region Variables

    //public GameObject ExplusionParticle;
    private Animator FadeInAnim;

    #endregion

    #region BuiltInMethods

    void Start()
    {
        FadeInAnim = GameManager.Instance.FadeInAnim;
    }

    
    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Rocket")
        {    
            /*
            FadeInAnim.enabled = true;
            other.gameObject.SetActive(false);
            
            Instantiate(ExplusionParticle,other.gameObject.transform.position,Quaternion.identity);
            */
            if(GameManager.Instance.Vibrate)
            {
               Handheld.Vibrate();
            }
         }
    }
    

    #endregion
}
