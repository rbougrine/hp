using UnityEngine;
using System.Collections;

public class PointerCounterModel : MonoBehaviour
{
    /// <summary>
    /// Created by Anny Aidinian
    /// Class that sends the score back to the database
    /// </summary>

    public string username;
    public int score;
    private MainInfo mainInfo;
    private ConfigureServer configureServer;

    /// <summary>
    /// Used for initialization
    /// </summary>

    void Start()
    {
        mainInfo = new MainInfo();
        configureServer = new ConfigureServer();
    }

    /// <summary>
    /// Sends back the points obtained by the user
    /// Triggered when user succesfully achieves excerise  
    /// </summary>

    public void SendInfo()
    {
        username = mainInfo.Login.Username;
        score = mainInfo.PointCounter.score;

        WWWForm form = new WWWForm();

        form.AddField("Username", username);
        form.AddField("score", score);
        form.AddField("Job", "SaveScore");

        configureServer.ServerConnection(form);

        StartCoroutine(saveInfo(configureServer.WWW));
     }

    /// <summary>
    /// Waits for API to send feedback,
    /// When it's not an error it will send a message confirming the transaction succes.
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
