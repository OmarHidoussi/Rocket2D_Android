using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    public bool State;

    public void OpenMenu(GameObject mainMenu)
    {
        mainMenu.SetActive(State);
    }
}
