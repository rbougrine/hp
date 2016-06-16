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
    private readonly string Ip = "145.24.222.160";


    void Start()
    {


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

        string url = "http://" + Ip + "/saveScore.php";

        WWWForm form = new WWWForm();

        form.AddField("username", username);
        form.AddField("score", score);
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

}
