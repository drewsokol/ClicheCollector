using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void PerformAction(string btn)
    {
        //do something based on the button that was passed in.
        if(btn == "ExitBtn")
        {
            PerformExit();
        }
    }

    public void PerformExit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }

}
