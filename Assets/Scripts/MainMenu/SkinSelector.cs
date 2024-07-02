using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelector : MonoBehaviour
{

    #region Variables

    public GameObject[] skins;
    public Sprite[] skinSprite;
    public Image renderedSprite;
    public int SelectedSkin;
    
    private int index;

    #endregion

    #region BuiltInMethods

    void Start()
    {
        index = PlayerPrefs.GetInt("SelectedSkin");
        renderedSprite.sprite = skinSprite[index];
    }

    void Update()
    {
        SelectedSkin = index;
    }

    #endregion

    #region CustomMethods
    
    public void NextOption()
    {
        if(index == skinSprite.Length-1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }

        renderedSprite.sprite = skinSprite[index];
        GameManager.Instance.SelectedSkin = index;

    }

    public void LastOption()
    {
        if(index < 1)
        {
            index = skinSprite.Length-1;
        }
        else
        {
            index -= 1; 
        }
        
        renderedSprite.sprite = skinSprite[index];
        GameManager.Instance.SelectedSkin = index;
    }

    #endregion

}
