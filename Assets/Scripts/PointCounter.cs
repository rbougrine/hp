using UnityEngine;
using System.Collections;

public class PointCounter : MonoBehaviour
{
    // score public for Ui design purpose
    public int score;
    // Camera set to main Camera of the cardboard to handle detactions of gameobjects
    public GameObject Camera;
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
    public void chosenObject()
    {
        RaycastHit hit;


        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, Mathf.Infinity))
        {
            var Cubes = hit.collider.gameObject.transform.name;
            Debug.Log(Cubes);

            // A swicth that determines whats happens after cubes gameobject is detected
            switch (Cubes)
            {
                case "Cubes":

                    score++;
                    Debug.Log(score);
                    Debug.Log(username);
                    if (score == 15) {
                       sendInfo();
                       Debug.Log("Score of user has been send");
                    }
            


                    break;
              
            }

        }
    }


    // Sending the score bacck to the database with including username and score
    void sendInfo()
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
            Debug.Log(www.text + "saveInfo");
        }

    }


}
