﻿using UnityEngine;
using System.Collections;

public class UiManG : MonoBehaviour
{

    /*
    * Created by Anny Aidinian.
    * 
    * Class that draws the GUI of the timer
    * 
    */


    private int playtime = 0;
    private int seconds = 0;
    private int minutes = 0;
    private int hours = 0;
    private MainInfo mainInfo;
    public GUIStyle timetyle;
 

    // Use this for initialization
    void Start()
    {

        mainInfo = new MainInfo();

    }


   
    /*
     * Fetches the time.
     * Draws the GUI.
     */

    public void TimerDisplay()
    {

        seconds = mainInfo.Timer.seconds;
        minutes = mainInfo.Timer.minutes;
        hours = mainInfo.Timer.hours;

        GUI.Box(new Rect(250, 150, 260, 20), "PlayedTime = " + hours.ToString() + " Hours:  " + minutes.ToString() + " Minutes:  " + seconds.ToString() + " Secondes  ", timetyle);


    }

}
