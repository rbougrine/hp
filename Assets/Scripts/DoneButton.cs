using System;
using UnityEngine;

class DoneButton : IButton
{
    /// <summary>
    /// Created by Randa Bougrine
    /// Class that implements the interface IButton
    /// The done button is used to finish the game
    /// </summary>

    private MainInfo mainInfo;
    private string result;

    /// <summary>
    /// Used for initialization
    /// </summary>

    public DoneButton()
    {   
        mainInfo = GameObject.Find("MainInfo").GetComponent<MainInfo>();       
    }

    /// <summary>
    /// Checks if excersie is done right 
    /// Triggerd when done button clicked.
    /// </summary>

    public void ClickedOn()
    {
     
        mainInfo.PanelManager.ReadState();
        mainInfo.PanelManager.CheckArray(mainInfo.PanelManager.userInput, mainInfo.Exercise.currentExercise);

        result = mainInfo.PanelManager.Result;

        if (result == "GoodJob")
        {
            mainInfo.PlayedtimeModel.Donetime();
            mainInfo.PointCounter.Addpoints();
            mainInfo.PanelManager.GoodJob.SetActive(true);
        }
        else
        {
            Debug.Log("Try again");
        }
    }
 }

