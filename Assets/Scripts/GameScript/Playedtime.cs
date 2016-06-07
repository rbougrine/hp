using UnityEngine;
using System.Collections;
using System;
using System.Globalization;

public class Playedtime : MonoBehaviour
{
    // Globale variable used in PlayedTime script

    

    private IEnumerator timer;
    private string time;
    public string Username;
    public int playtime = 0;
    public int seconds = 0;
    public int minutes = 0;
    public int hours = 0;
    public UiManG gui;
    private GameObject Gui;
    public DateTime starttime, endtime;
    

    void Start()
    {
        // Get informatie 
        Getinformation();
        timer = Playtimer();
        gui = Gui.GetComponent<UiManG>();
    }



    public UiManG GUI
    {
        get
        {
            return gui;

        }
    }


    public void Donetime() {

     
        StopCoroutine(timer);
        endtime = DateTime.Now;
        Debug.Log(endtime);
        Debug.Log("ik eindig");
        PlayedtimeModel Timer = GameObject.Find("Timer").GetComponent<PlayedtimeModel>();
     
    
        time = hours.ToString() + minutes.ToString() + seconds.ToString();
        Debug.Log(time);
        Timer.SendInfo();
        Debug.Log("Total time played by user has been send to the database");
        Debug.Log("gespeelde tijd");
        Debug.Log(endtime - starttime);


    }

    public void StartTimer()
    {
        starttime = DateTime.Now;
        Debug.Log(starttime);
        Debug.Log("ik begin");
        StartCoroutine(timer);
        starttime.ToLongDateString();
        
    }


    public  IEnumerator Playtimer()
    {
       // Timer created and set as courtine 
        while (true)
        {
            yield return new WaitForSeconds(1);
            playtime += 1;
            seconds = (playtime % 60);
            minutes = (playtime / 60) % 60;
            hours = (playtime / 3600) % 24;
      
            
        }

    }

    void Getinformation()
    {
        /*
        - Get username from statusbar of the current user
        - To use for updating the  users score in the game tabel
        */
        GameObject statusbar = GameObject.Find("StatusBar");
        StatusBarModel status = statusbar.GetComponent<StatusBarModel>();
   
        // set username from status to Username 
        Username = status.username;
        Debug.Log(Username);

   

    }


    void OnGUI()
    {

        gui.TimerDisplay();


    }
}






