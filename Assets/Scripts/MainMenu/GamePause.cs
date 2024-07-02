using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePause : MonoBehaviour
{

    #region Variables

    public bool Pause;
    public float ResetTimeScale;

    public Image spriteRenderer;
    public Sprite[] Sprites;

    #endregion

    #region BuiltInMethods

    void Start() 
    {
        ResetTimeScale = Time.timeScale;
    }

    #endregion

    #region CutomMethods

    public void PauseGame()
    {
        Pause = !Pause;

        if(!Pause)
        {
            Time.timeScale = ResetTimeScale;
            AudioListener.volume = 1f;
            
            spriteRenderer.sprite = Sprites[0];
        }
        else
        {
            AudioListener.volume = 0f;
            Time.timeScale = 0f;

            spriteRenderer.sprite = Sprites[1];
        }
    }

    #endregion

}
