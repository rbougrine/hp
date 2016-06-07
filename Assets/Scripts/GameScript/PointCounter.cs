using UnityEngine;
using System.Collections;

public class PointCounter : MonoBehaviour
{
    // score public for Ui design purpose
    public int score;
    public string username;
   
    // Use this for initialization
    void Start()
    {
       
        Getinformation();

    }


    void Getinformation()
    {

        // get Score and Username from statusbar of the current user
        GameObject statusbar = GameObject.Find("StatusBar");
        StatusBarModel status = statusbar.GetComponent<StatusBarModel>();
        score = status.score;
        username = status.username;
        Debug.Log(score);
        Debug.Log("hierrrrr2");



    }



    public void Addpoints()
    {
        GameObject point = GameObject.Find("Score");
        PointerCounterModel points = point.GetComponent<PointerCounterModel>();
       


        score  += 10;
        Debug.Log(score);
        points.SendInfo();
        Debug.Log(score);
        Debug.Log("Total score user has been send to the database");
        Debug.Log(score);
    }






}
