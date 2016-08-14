using UnityEngine;
using UnityEngine.SceneManagement;

public class StatusBarView : MonoBehaviour, IBar
{
    /// <summary>
    /// Created by Anny Aidinian.
    /// Class that creates the statusbar GUI
    /// Implements the interface IBar
    /// </summary>

    public string InfoStatusbar, InfoStatusbarScore;
    private int score;
    public GUIStyle labelStyle, scorestyle;
    private MainInfo mainInfo;

    /// <summary>
    /// Used for initialization
    /// </summary>

    void Start()
    {
        mainInfo = GameObject.Find("MainInfo").GetComponent<MainInfo>();
    }

    /// <summary>
    /// Generates the GUI
    /// </summary>

    void OnGUI()
    {      
        var currentMenu = mainInfo.Login.CurrentMenu;
        if (currentMenu == null)
        {           
            Bar();       
        }
    }

    /// <summary>
    /// Draws the GUI of the statusbar with userinformation.
    /// Whichever condition is met, the score is fetches from other classes.
    /// </summary>

    public void Bar()
    {
        InfoStatusbar = mainInfo.StatusBarModel.infoStatusbar;

        GUI.Box(new Rect(250, 150, 260, 20), InfoStatusbar, labelStyle);

        if (SceneManager.GetActiveScene().name == "Game")
        {
            Score = mainInfo.StatusBarModel.score;
            GUI.Label(new Rect(250, 150, 260, 20), score.ToString(), scorestyle);
        }
        else
        {
            Score = mainInfo.PointCounter.score;
            GUI.Label(new Rect(250, 150, 260, 20), score.ToString(), scorestyle);
        }
    }

    /// <summary>
    /// Method from the interface IBar
    /// its not used in this class
    /// </summary>

    public void TimerDisplay(){}
 
    /// <summary>
    /// Getter and Setter for the int Score
    /// </summary>

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }
}

