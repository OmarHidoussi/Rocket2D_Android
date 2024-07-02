using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAudio : MonoBehaviour
{

    #region Variables

    public AudioSource audio;
    public AudioClip[] clip;

    #endregion

    #region BuiltInMethods

    void Start()
    {
        audio = GetComponentInChildren<AudioSource>();
    }

    #endregion

    #region CustomMethods
    
    public void playItemPickUpSound()
    {
        audio.clip = clip[1];
        audio.Play();
    }

    #endregion

}
