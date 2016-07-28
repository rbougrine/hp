using UnityEngine;
using System.Collections;
using System;


public class PlayedTimeView : MonoBehaviour, IBar
{
    /// <summary>
    /// Created by Anny Aidinian.
    /// Class that draws the GUI of the timer
    /// </summary>

    public bool timerBool;
    private int playtime;
    private int seconds;
    private int minutes ;
    private int hours;
    private MainInfo mainInfo;
    public GUIStyle timetyle;
    private PlayedtimeModel playedtimeModel;

    /// <summary>
    /// Used for initialization
    /// </summary>

    void Start()
    {
        mainInfo = new MainInfo();
    }

    /// <summary>
    /// Get and set method for score
    /// </summary>

    public int Score
    {
        get;
        set;
     }

    /// <summary>
    /// empty class from the interface, isn't used
    /// </summary>

     public void Bar() { }

    /// <summary>
    /// When bool is true show the GUI
    /// </summary>

    void OnGUI()
    {
        if (timerBool != false)
        {
            TimerDisplay();
        }
    }

    /// <summary>
    /// Fetches the time
    /// Draws the GUI
    /// </summary>

    public void TimerDisplay()
    {
        hours = mainInfo.PlaytimeModel.hours;
        minutes = mainInfo.PlaytimeModel.minutes;
        seconds = mainInfo.PlaytimeModel.seconds;

        GUI.Box(new Rect(250, 150, 260, 20), "PlayedTime = " + hours.ToString() + " Hours:  " + minutes.ToString() + " Minutes:  " + seconds.ToString() + " Secondes  ", timetyle);
    }     
}
