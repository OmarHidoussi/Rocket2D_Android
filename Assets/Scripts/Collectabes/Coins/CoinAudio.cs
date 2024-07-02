using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinAudio : MonoBehaviour
{

    #region Variables

    private AudioSource audioSource;

    #endregion

    #region BuiltInMethods

    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //audioSource.pitch = GameManager.Instance.AudioPitch;
    }

    #endregion

    #region CustomMethods

    #endregion

}
