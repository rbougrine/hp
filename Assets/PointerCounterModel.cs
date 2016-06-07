using UnityEngine;
using System.Collections;

public class PointerCounterModel : MonoBehaviour {
    public string username;
    public int score;
	// Use this for initialization
	void Start () {

       
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    // Sending the score bacck to the database with including username and score
  public void SendInfo()
    {

        // GameObject point = GameObject.Find("Score");
        // PointCounter points = point.GetComponent<PointCounter>();
        PointCounter scoree = GameObject.Find("Score").GetComponent<PointCounter>();
        username = scoree.username;
        score = scoree.score;

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
             Debug.Log(www.text + "saveInfo");
        }

    }

}
