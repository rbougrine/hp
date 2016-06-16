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
    private PanelMan panelManager;
    private Door check;
    public GameObject manager, door, GoodJob, StartButton, Point, timer;
    private StartButton start;
    private PointCounter points;
    private Playedtime time;

    string result;

    // Use this for initialization
    void Start()
    {
        start = StartButton.GetComponent<StartButton>();
        panelManager = manager.GetComponent<PanelMan>();
        check = door.GetComponent<Door>();
        points = Point.GetComponent<PointCounter>();
        time = timer.GetComponent<Playedtime>();
        exerciseOne = new int[] { 7, 11, 4, 11, 5, 16, 0, 0, 0, 16, 2, 0, 0, 0, 16, 8, 11, 14, 11, 6, 0, 0, 0, 0, 0 };
        exerciseTwo = new int[] { 7, 11, 4, 11, 5, 16, 0, 0, 0, 1, 15, 0, 0, 0, 16, 16, 0, 0, 0, 2, 8, 11, 11, 14, 11, 6 };
        exerciseThree = new int[] { 7, 11, 4, 11, 5, 16, 0, 0, 0, 16, 12, 11, 14, 17, 13, 16, 0, 0, 0, 16, 8, 11, 14, 11, 6 };
    }

    void OnGUI()
    {
        if (result == "TryAgain")
        {
            Debug.Log("Try Again");
        }



    }



    public PointCounter Points
    {
        get
        {
            return points;

        }


    }


    public Playedtime Time
    {
        get
        {
            return time;

        }
    }


    public Door Door
    {
        get
        {
            return check;

        }


    }
    public StartButton Startbutton
    {
        get
        {
            return start;

        }


    }
    public PanelMan PanelManager
    {
        get
        {
            return panelManager;

        }


    }

    public void CheatButton()
    {
        PanelManager.CheatState(Startbutton.currentExercise);
    }

    /*
    * Checks if excersie is done right 
    *Triggerd when done button clicked.
    */

    public void FinalState()
    {
        PanelManager.ReadState();
        PanelManager.CheckArray(PanelManager.userInput, Startbutton.currentExercise);
        //  Debug.Log(Startbutton.currentExercise[10]);

        result = PanelManager.Result;

        switch (result)
        {
            case "GoodJob":
                time.Donetime();
                points.Addpoints();
                GoodJob.SetActive(true);
                break;

        }

    }

    public void GoodJobButton()
    {
        Debug.Log(check.SeenObject.name);
        if (check.SeenObject.name == "next")
        {
            GoodJob.SetActive(false);
        }
        else
        {


            GoodJob.SetActive(false);


        }

    }
}
