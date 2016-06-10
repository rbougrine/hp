using UnityEngine;
using System.Collections;
using System;

public class PlayedtimeModel : MonoBehaviour {

    public DateTime starttime, endtime;
    private string Username;
    private readonly string ip = "145.24.222.160";

    // Use this for initialization
    void Start () {
	
	}

    // Sending the score bacck to database with including username and score
    public void SendInfo()
    {
        Playedtime timer = GameObject.Find("Timer").GetComponent<Playedtime>();
        Username = timer.Username;
        starttime = timer.starttime;
        endtime = timer.endtime;

        // php file from server where savingtime is processing
        string url = "http://" + ip + "/saveTime.php";

        WWWForm form = new WWWForm();

        form.AddField("username", Username);
        form.AddField("begintime", starttime.ToLongTimeString());
        form.AddField("endtime", endtime.ToLongTimeString());
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
            // Debug.Log(www.text + "saveInfo");
        }

    }


}
