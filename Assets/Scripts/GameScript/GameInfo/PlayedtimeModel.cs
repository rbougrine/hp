using UnityEngine;
using System.Collections;
using System;

public class PlayedtimeModel : MonoBehaviour
{
    /// <summary>
    /// Created by Anny Aidinian
    /// Class that handles the time when the game is played
    /// Sends time to be saved in the database
    /// </summary>

    public DateTime starttime, endtime;
    private ConfigureServer configureServer;
    public int playtime = 0;
    public int seconds = 0;
    public int minutes = 0;
    public int hours = 0;
    private string username;
    private MainInfo mainInfo;
    private string time;


    /// <summary>
    /// Used for initialization
    /// </summary>
    
    void Start()
    {
        mainInfo = new MainInfo();
        configureServer = new ConfigureServer();
        username = mainInfo.Login.Username;
    }
    /// <summary>
    /// Starts the timer, called in the class StartButton
    /// </summary>

    public void StartTimer()
    {
        starttime = DateTime.Now;
        StartCoroutine(Playtimer());
        mainInfo.GarageGUI.timerBool = true;
        starttime.ToLongDateString();

    }

    /// <summary>
    /// Triggers when the user succesfully is done with the exercise,
    /// current time is selected as endtime which is used to calculate the  time used for the exercise
    /// </summary>

    public void Donetime()
    {
        StopCoroutine(Playtimer());
        endtime = DateTime.Now;
        time = hours.ToString() + minutes.ToString() + seconds.ToString();
        SendInfo();
    }

    /// <summary>
    /// Timer for the GUI is created and when puzzel game is started
    /// </summary>

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

    /// <summary>
    /// Sending the score back to database including username and achieved score
    /// </summary>

    public void SendInfo()
    {
        WWWForm form = new WWWForm();

        form.AddField("Username", username);
        form.AddField("Begintime", starttime.ToLongTimeString());
        form.AddField("Endtime", endtime.ToLongTimeString());
        form.AddField("Job", "SaveTime");

        configureServer.ServerConnection(form);

        StartCoroutine(saveInfo(configureServer.WWW));

    }

    /// <summary>
    /// Waits for feedback from the serverside
    /// Shows error when it isn't succesful
    /// </summary>

    IEnumerator saveInfo(WWW www)
    {
        yield return www;

        if (www.error != null)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.text);
        }
    }
}
