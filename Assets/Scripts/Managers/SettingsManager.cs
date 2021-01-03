using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SettingsManager : MonoBehaviour
{
    private void Start()
    {
        Screen.fullScreen = true;
        ApplicationChrome.navigationBarState = ApplicationChrome.States.Hidden;
        ApplicationChrome.statusBarState     = ApplicationChrome.States.Visible;
        ApplicationChrome.statusBarColor     = 0xff;
    }
}
