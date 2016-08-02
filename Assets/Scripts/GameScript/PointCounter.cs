using UnityEngine;


public class PointCounter : MonoBehaviour
{
    /// <summary>
    /// Created by Anny Aidinian.
    /// Class that controls adding points
    /// </summary>

    public int score;
    public string username;
    private MainInfo mainInfo;

    /// <summary>
    /// Used for initialization
    /// </summary>

    void Start()
    {
        mainInfo = GameObject.Find("MainInfo").GetComponent<MainInfo>();
    }

    /// <summary>
    /// Fetches the user information from the Statusbar
    /// </summary>

    public void Getinformation()
    {
        score = mainInfo.StatusBarModel.score;
        username = mainInfo.StatusBarModel.username;
    }

    /// <summary>
    /// Adds points to the score when exercise is succesfully done
    /// </summary>

    public void Addpoints()
    {
        score += 10;
        mainInfo.PointerCounterModel.SendInfo();
    }
}
