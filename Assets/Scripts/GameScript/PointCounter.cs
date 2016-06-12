using UnityEngine;
using System.Collections;

public class PointCounter : MonoBehaviour
{
    /*
    * Created by Anny Aidinian.
    * 
    * Class that controls adding points
    *
    */

    public int score;
    public string username;



    void Start()
    {

        Getinformation();

    }

    /*
    * Fetches the user information from the Statusbar
    */

    void Getinformation()
    {
        GameObject statusbar = GameObject.Find("StatusBar");
        StatusBarModel status = statusbar.GetComponent<StatusBarModel>();
        score = status.score;
        username = status.username;




    }

    /*
     * Adds points to the score when exercise is succesfully done
     */

    public void Addpoints()
    {
        GameObject point = GameObject.Find("Score");
        PointerCounterModel points = point.GetComponent<PointerCounterModel>();
        score += 10;
        points.SendInfo();

    }






}
