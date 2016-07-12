using UnityEngine;
using System.Collections;
using System;

public class PlayedtimeModel : MonoBehaviour {

    public DateTime starttime, endtime;
    public int playtime = 0;
    public int seconds = 0;
    public int minutes = 0;
    public int hours = 0;
    private string Username;
    private MainInfo mainInfo;
    private IEnumerator timer;
    private string time;


    // Use this for initialization
    void Start ()
    {
        mainInfo = new MainInfo();
        timer = Playtimer();
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
        time = hours.ToString() + minutes.ToString() + seconds.ToString();
    
        SendInfo();
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


    // Sending the score bacck to database with including username and score
    public void SendInfo()
    {

        Username = mainInfo.Login.Username;
       

        // php file from server where savingtime is processing
     
        WWWForm form = new WWWForm();

        form.AddField("Username", Username);
        form.AddField("Begintime", starttime.ToLongTimeString());
        form.AddField("Endtime", endtime.ToLongTimeString());
        form.AddField("Job", "SaveTime");
        WWW www = new WWW(mainInfo.URL, form);

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


}
