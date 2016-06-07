using UnityEngine;
using System.Collections;

public class PointerCounterModel : MonoBehaviour {
    public string username;
    public int score;
    private readonly string ip = "145.24.222.160";
    // Use this for initialization
    void Start () {

       
    }
	
    // Sending the score bacck to the database with including username and score
  public void SendInfo()
    {
        PointCounter scoree = GameObject.Find("Score").GetComponent<PointCounter>();
        username = scoree.username;
        score = scoree.score;

        string url = "http://" + ip + "/saveScore.php";

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
