using UnityEngine;
using System.Collections;
using System;
using System.Globalization;

public class Playedtime : MonoBehaviour
{
    /*
   * Created by Anny Aidinian.
   * 
   * Class that manages which information box is set visible
   * 
   */


    // Globale variable used in PlayedTime script
    private IEnumerator timer;
    private MainInfo mainInfo;
    private string time;
    public string Username;
    public int playtime = 0;
    public int seconds = 0;
    public int minutes = 0;
    public int hours = 0;
   
    public DateTime starttime, endtime;
  


    void Start()
    {
        timer = Playtimer();
        mainInfo = new MainInfo();       
        Username = mainInfo.Login.Username;

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
       
       
        PlayedtimeModel Timer = GameObject.Find("Timer").GetComponent<PlayedtimeModel>();

        time = hours.ToString() + minutes.ToString() + seconds.ToString();
      
        Timer.SendInfo();
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


    /*
    * Starts the GUI to draw the timer
    */
    void OnGUI()
    {

        mainInfo.GarageGUI.TimerDisplay();


    }
}






