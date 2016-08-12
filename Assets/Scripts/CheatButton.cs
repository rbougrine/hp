using System;
using UnityEngine;


class CheatButton : MonoBehaviour, IButton
{
    /// <summary>
    /// Created by Randa Bougrine
    /// Class that implements the interface IButton
    /// manages the cheat button
    /// </summary>

    public int[] userInput;
    private int[] exercise;
    private MainInfo mainInfo;

    /// <summary>
    /// Used for initialization
    /// </summary>

    public CheatButton()
    {
        mainInfo = GameObject.Find("MainInfo").GetComponent<MainInfo>();
    }

    /// <summary>
    /// Shows the correct answer on the panels
    /// </summary>

    public void ClickedOn()
    {
        exercise = mainInfo.Exercise.currentExercise;
        mainInfo.PanelManager.CheatState(exercise);
    }
    
   
}

