using UnityEngine;
using System.Collections;

public class PointCounter : MonoBehaviour
{
    // score public for Ui design purpose
    public int score;
    private string username;
   
    // Use this for initialization
    void Start()
    {
       
        Getinformation();

    }


    void Getinformation()
    {

        // get Score and Username from statusbar of the current user
        GameObject statusbar = GameObject.Find("StatusBar");
        StatusBar status = statusbar.GetComponent<StatusBar>();
        score = status.score;
        username = status.username;
        Debug.Log(score);



    }

    /*
    - Detect with raycast which object is clicked  
    - If Cube is clicked with cardboard then assign points to score
    - Send info to databae with sendinfo() methothd when user clicks on the garage door
    */



    public void Addpoints()
    {
        
        score  += 10;
        SendInfo();
        Debug.Log("Total score user has been send to the database");

    }




    // Sending the score bacck to the database with including username and score
    void SendInfo()
    {
        // php file from server where savingscore is processing
        string url = "http://145.24.222.160/saveScore.php";

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
           // Debug.Log(www.text + "saveInfo");
        }

    }


}
