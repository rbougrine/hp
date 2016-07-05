using UnityEngine;
using System.Collections;
using System;

public class PlayedtimeModel : MonoBehaviour {

    public DateTime starttime, endtime;
    private string Username;
    private MainInfo mainInfo;

    // Use this for initialization
    void Start ()
    {
        mainInfo = new MainInfo();
	}

    // Sending the score bacck to database with including username and score
    public void SendInfo()
    {
        Playedtime timer = GameObject.Find("Timer").GetComponent<Playedtime>();
        Username = mainInfo.Login.Username;
        starttime = timer.starttime;
        endtime = timer.endtime;

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
