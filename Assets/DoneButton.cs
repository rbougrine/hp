using UnityEngine;
using System.Collections;

public class DoneButton : MonoBehaviour
{
    private PanelMan panelManager;
    private Door check;
    public int[] exerciseOne;
    public int[] exerciseTwo;
    public int[] exerciseThree;
    public int exercise;
    public GameObject manager;
    public GameObject door;
    public GameObject GoodJob;
    public GameObject StartButton;
    private StartButton start;
    string result;

    // Use this for initialization
    void Start()
    {
        start = StartButton.GetComponent<StartButton>();
        panelManager =  manager.GetComponent<PanelMan>();
        check = door.GetComponent<Door>();
        exerciseOne = new int[] { 7, 11, 4, 11, 5, 16, 0, 0, 0, 16, 2, 0, 0, 0, 16, 8, 11, 14, 11, 6, 0, 0, 0, 0, 0};
        exerciseTwo = new int[] { 7, 11, 4, 11, 5, 16, 0, 0, 0, 1, 15, 0, 0, 0, 16, 16, 0, 0, 0, 2, 8, 11, 11, 14, 11, 6};
        exerciseThree = new int[] {7, 11, 4, 11, 5, 16, 0, 0, 0, 16, 12, 11, 14, 17, 13, 16, 0, 0, 0, 16, 8, 11, 14, 11, 6};
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (result == "TryAgain")
        {
         //   Debug.Log("Try Again");
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

    public void cheatButton()
    {
        PanelManager.cheatState(Startbutton.currentExercise);
    }

    public void finalState()
    {
        PanelManager.readState();
        PanelManager.checkArray(PanelManager.userInput, Startbutton.currentExercise);
    //  Debug.Log(Startbutton.currentExercise[10]);

        result =  PanelManager.Result;
      
        switch (result)
        {
            case "GoodJob":
                GoodJob.SetActive(true);
                break;

        }
              
    }

    public void GoodJobButton()
    {
        Debug.Log(check.SeenObject.name);
        if (check.SeenObject.name == "next")
        {
            Debug.Log("next");
        }
        else
        {
            GoodJob.SetActive(false);
        }

    }
}
