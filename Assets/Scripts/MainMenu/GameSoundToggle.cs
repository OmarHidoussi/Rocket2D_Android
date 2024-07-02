using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSoundToggle : MonoBehaviour
{

    #region Variables

    public bool SoundOn;

    public Image spriteRenderer;
    public Sprite[] Sprites;
    public AudioListener listener;

    #endregion

    #region BuiltInMethods

    #endregion

    #region CustomMethods

    public void SoundToggle()
    {
        SoundOn = !SoundOn;

        if(!SoundOn)
        {
            AudioListener.volume = 1f;
            spriteRenderer.sprite = Sprites[0];
        }
        else
        {
            AudioListener.volume = 0f;
            spriteRenderer.sprite = Sprites[1];
        }
    }

    #endregion

}
