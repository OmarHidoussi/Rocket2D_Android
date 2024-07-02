using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{

    #region Variables

    public SpriteRenderer sprite;
    public SpriteRenderer sprite_2;
    public float newAlpha;
    public float WaitTime;

    public float FadeOutTime;
    public float Timer;
    public float TransSpeed;

    #endregion

    #region BuiltInMethods

    void Start()
    {   

        newAlpha = 0;
    }

    void Update()
    {
        Timer += Time.deltaTime;

        if(Timer > WaitTime)
        {
            Timer = 0f;
        }

        if(Timer > FadeOutTime)
        {
            newAlpha = Mathf.Lerp(newAlpha , 0, TransSpeed * Time.deltaTime);
        }
        else
        {
            newAlpha = Mathf.Lerp(newAlpha, 1 , TransSpeed * Time.deltaTime);
        }

        sprite.color = new Color(sprite.color.r,sprite.color.g,sprite.color.b,newAlpha);
       
        sprite_2.color = new Color(sprite_2.color.r,sprite_2.color.g,sprite_2.color.b,newAlpha);

    }

    #endregion

}
