using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Scripts.Interfaces;
using System;

public class StatusBarView : MonoBehaviour, IBar
{

    /*
   * Created by Anny Aidinian.
   * 
   * Class that creates the statusbar Gui
   * 
   */


    public string InfoStatusbar, InfoStatusbarScore;
    private int score;
    public GUIStyle labelStyle, scorestyle;
    private MainInfo mainInfo;



    public int Score
    {
        get
        {
            return score;
        }
        set {

            score = value;
        }

    }

   

    void Start()
    {

        mainInfo = new MainInfo();
      
    }




    void OnGUI()
    {
    
        var CurrentMenu = login.CurrentMenu;

        Debug.Log(login.CurrentMenu);
        if (CurrentMenu == null)
        {
         
          
            Bar();
         
        }


    }

    /*
     * Draws the GUI of the statusbar with userinformation.
     * Whichever condition is met, the score is fetches from other classes.
    */


    public void Bar()
    {
        InfoStatusbar = mainInfo.StatusBarModel.InfoStatusbar;
        GUI.Box(new Rect(250, 150, 260, 20), InfoStatusbar, labelStyle);

        if (SceneManager.GetActiveScene().name == "Game")

        {
            Score = mainInfo.StatusBarModel.score;
            GUI.Label(new Rect(250, 150, 260, 20), score.ToString(), scorestyle);


        }
        else {

            Score = mainInfo.Points.score;
            GUI.Label(new Rect(250, 150, 260, 20), score.ToString(), scorestyle);


        }

    }

    public void TimerDisplay()
    {
        
    }
}

