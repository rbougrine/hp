using UnityEngine;
using System.Collections;

public class DoneButton : MonoBehaviour
{

    /*
    * Created by Randa & Anny Aidinian.
    * 
    * Class that managing ending process of game 
    * Triggerd when done button is pressed 
    */


    public int[] exerciseOne;
    public int[] exerciseTwo;
    public int[] exerciseThree;

    public int exercise;
    private MainInfo mainInfo;
    public GameObject GoodJob;
    string result;

    // Use this for initialization
    void Start()
    {
        mainInfo = new MainInfo();
        exerciseOne = new int[] { 7, 11, 4, 11, 5, 16, 0, 0, 0, 16, 2, 0, 0, 0, 16, 8, 11, 14, 11, 6, 0, 0, 0, 0, 0 };
        exerciseTwo = new int[] { 7, 11, 4, 11, 5, 16, 0, 0, 0, 1, 15, 0, 0, 0, 16, 16, 0, 0, 0, 2, 8, 11, 11, 14, 11, 6 };
        exerciseThree = new int[] { 7, 11, 4, 11, 5, 16, 0, 0, 0, 16, 12, 11, 14, 17, 13, 16, 0, 0, 0, 16, 8, 11, 14, 11, 6 };
    }

    public void CheatButton()
    {
       mainInfo.PanelManager.CheatState(mainInfo.StartButton.currentExercise);
    }

    /*
    * Checks if excersie is done right 
    *Triggerd when done button clicked.
    */

    public void FinalState()
    {
        mainInfo.PanelManager.ReadState();
        mainInfo.PanelManager.CheckArray(mainInfo.PanelManager.userInput, mainInfo.StartButton.currentExercise);   

        result = mainInfo.PanelManager.Result;

        if (result == "GoodJob")
        {
            mainInfo.Time.Donetime();
            mainInfo.Points.Addpoints();
            GoodJob.SetActive(true);
        }
        else
        {
            Debug.Log("Try again");
        }
    }

    public void GoodJobButton()
    {
        Debug.Log(mainInfo.Door.SeenObject.name);

        if (mainInfo.Door.SeenObject.name == "next")
        {
            GoodJob.SetActive(false);
            mainInfo.StartButton.BeginState();

        }
        else
        {
            GoodJob.SetActive(false);
        }

    }
}
