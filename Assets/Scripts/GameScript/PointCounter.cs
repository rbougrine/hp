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
    private MainInfo mainInfo;

   
    void Start()
    {
        mainInfo = new MainInfo();
        Getinformation();

    }

    /*
    * Fetches the user information from the Statusbar
    */

    void Getinformation()
    {
      
        score = mainInfo.StatusBarModel.score;
        username = mainInfo.StatusBarModel.username;
    }

    /*
     * Adds points to the score when exercise is succesfully done
     */

    public void Addpoints()
    {
    
        score += 10;
        mainInfo.PointerCounterModel.SendInfo();

    }






}
