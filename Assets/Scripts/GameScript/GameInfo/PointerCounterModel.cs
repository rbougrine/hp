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


    void Start()
    {
        mainInfo = new MainInfo();

    }

    /*
    * Sends back the points obtained by the user
    * Triggered when user succesfully achieves excerise  
    */

    public void SendInfo()
    {
        PointCounter scoree = GameObject.Find("Score").GetComponent<PointCounter>();
        username = scoree.username;
        score = scoree.score;

   

        WWWForm form = new WWWForm();

        form.AddField("username", username);
        form.AddField("score", score);
        form.AddField("Job", "SaveScore");
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
