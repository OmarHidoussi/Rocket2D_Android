using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{

    #region Variables
    
    public string scene; 

    #endregion

    #region CustomMethods

    public void ReloadScene(string _scene)
    {
        _scene = scene;
        SceneManager.LoadScene(_scene); 
    }

    #endregion

}
