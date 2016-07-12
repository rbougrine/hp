using UnityEngine;
using System.Collections;
using System;

public class PlayedTimeView : MonoBehaviour
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
   
    // Globale variable used in PlayedTime script
    private IEnumerator timer;
    private string time;
    public string Username;
    

    public DateTime starttime, endtime;


    // Use this for initialization
    void Start()
    {
        timer = Playtimer();
        mainInfo = new MainInfo();

    }

    /*
   * Triggers when the user clicks on the Start game object.
   * current time is selected as starttime
   */
    public void StartTimer()
    {
        starttime = DateTime.Now;
        StartCoroutine(timer);
        starttime.ToLongDateString();

    }



    /*
    * Triggers when the user succesfully is done with the exercise.
    * current time is selected as endtime
    */

    public void Donetime()
    {

        StopCoroutine(timer);
        endtime = DateTime.Now;


     
        time = hours.ToString() + minutes.ToString() + seconds.ToString();

        mainInfo.Time.SendInfo();

  
        Debug.Log(endtime - starttime);


    }

    /*
    * Timer for the GUI is created and when puzzel game is started
    *
    */
    public IEnumerator Playtimer()
    {

        while (true)
        {
            yield return new WaitForSeconds(1);
            playtime += 1;
            seconds = (playtime % 60);
            minutes = (playtime / 60) % 60;
            hours = (playtime / 3600) % 24;


        }

    }




    void OnGUI()
    {

        TimerDisplay();


    }


/*
 * Fetches the time.
 * Draws the GUI.
 */

public void TimerDisplay()
    {


        GUI.Box(new Rect(250, 150, 260, 20), "PlayedTime = " + hours.ToString() + " Hours:  " + minutes.ToString() + " Minutes:  " + seconds.ToString() + " Secondes  ", timetyle);


    }

}
