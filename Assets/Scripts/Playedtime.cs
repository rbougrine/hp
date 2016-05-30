using UnityEngine;
using System.Collections;
using System;
using System.Globalization;

public class Playedtime : MonoBehaviour
{
    // Globale variable used in PlayedTime script

    public GUIStyle timetyle;

    private IEnumerator timer;
    private string time;
    private string Username;
    private int playtime = 0;
    private int seconds = 0;
    private int minutes = 0;
    private int hours = 0;

  





    void Start()
    {
        // Get informatie 
        Getinformation();
        timer = Playtimer();
        startTimer();

    }



    public void donetime() {

        /*
        - Stop timer when clicked on garage door,
        - And data to database
        */
        StopCoroutine(timer);
        time = hours.ToString() + minutes.ToString() + seconds.ToString();
        sendInfo();
        Debug.Log("Total time played by user has been send to the database");
     

    }

    public void startTimer()
    {
        // method to start timer when player clicking on garage door 
        StartCoroutine(timer);
 
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
        StatusBar status = statusbar.GetComponent<StatusBar>();
   
        // set username from status to Username 
        Username = status.username;
        Debug.Log(Username);

   

    }

    // Sending the score bacck to database with including username and score
    void sendInfo()
    {
        // php file from server where savingtime is processing
        string url = "http://145.24.222.160/saveTime.php";

        WWWForm form = new WWWForm();

        form.AddField("username", Username);
        form.AddField("time", time);
        WWW www = new WWW(url, form);

        StartCoroutine(saveInfo(www));

    }

    IEnumerator saveInfo(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error != null)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.text + "saveInfo");
        }

    }


    void OnGUI()
    {
        timerDisplay();
    }


    void timerDisplay()
    {
       // displaying timer on screen
        GUI.Box(new Rect(250, 150, 260, 20), "PlayedTime = " +  hours.ToString() + " Hours:  " +  minutes.ToString() + " Minutes:  " + seconds.ToString() + " Secondes  ", timetyle);
  

    }
    
}






