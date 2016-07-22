using UnityEngine;
using System.Collections;

public class PointerCounterModel : MonoBehaviour
{


    /*
    * Created by Anny Aidinian.
    * 
    * Class that sends the score back to the database
    * 
    */

    public string username;
    public int score;
    private MainInfo mainInfo;
    private ConfigureServer configureServer;

    void Start()
    {
        mainInfo = new MainInfo();
        configureServer = new ConfigureServer();
    }

    /*
    * Sends back the points obtained by the user
    * Triggered when user succesfully achieves excerise  
    */

    public void SendInfo()
    {
      
  
        username = mainInfo.Login.Username;
        score = mainInfo.Points.score;

   
        WWWForm form = new WWWForm();

        form.AddField("Username", username);
        form.AddField("score", score);
        form.AddField("Job", "SaveScore");

        configureServer.ServerConnection(form);

        StartCoroutine(saveInfo(configureServer.WWW));
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
