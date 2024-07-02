using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class TapToPlay : MonoBehaviour
{

    #region Variables

    public Animator taptoplay;
    public AudioSource Playaudio;

    public SkinSelector selectedSkin;
    public GameObject[] Skins;

    public Button btn;

    #endregion

    #region BuiltInMethods

    private void Awake() 
    {
        taptoplay = GetComponentInChildren<Animator>();
        
        Playaudio = GetComponent<AudioSource>();
    }

    #endregion

    #region CustomMethods

    public void StartGame()
    {
        taptoplay.SetBool("StartGame",true);

        Playaudio.Play();

        Skins[selectedSkin.SelectedSkin].SetActive(true);

        btn.enabled = false;

    } 

    #endregion

}
