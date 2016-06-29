using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIMan : MonoBehaviour
{

    /*
   * Created by Anny Aidinian.
   * 
   * Class that creates the statusbar Gui
   * 
   */


    public string InfoStatusbar, InfoStatusbarScore;
    public int score;
    public GUIStyle labelStyle, scorestyle;
    private MainInfo mainInfo;




    void Start()
    {

        mainInfo = new MainInfo();
     
    }


    /*
    *Ensures that the statusbar is sent along to the next scene.
    */

    void Awake()
    {
        DontDestroyOnLoad(this);

    }


    /*
     * Draws the GUI of the statusbar with userinformation.
     * Whichever condition is met, the score is fetches from other classes.
    */


    public void Bar()
    {
        InfoStatusbar = mainInfo.StatusBarModel.InfoStatusbar;
        InfoStatusbarScore = mainInfo.StatusBarModel.InfoStatusbarScore;
        GUI.Box(new Rect(250, 150, 260, 20), InfoStatusbar, labelStyle);

        if (SceneManager.GetActiveScene().name == "Game")

        {
            StatusBarModel status = GameObject.Find("StatusBar").GetComponent<StatusBarModel>();
            score = status.score;
            GUI.Label(new Rect(250, 150, 260, 20), score.ToString(), scorestyle);


        }
        else {

            PointCounter points = GameObject.Find("Score").GetComponent<PointCounter>();
            score = points.score;
            GUI.Label(new Rect(250, 150, 260, 20), score.ToString(), scorestyle);


        }



    }
}
