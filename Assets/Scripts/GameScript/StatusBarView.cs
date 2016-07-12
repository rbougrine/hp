using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StatusBarView : MonoBehaviour
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




    void OnGUI()
    {
    //    var CurrentMenu = mainInfo.Login.CurrentMenu;

       // if (CurrentMenu == null)
     //   {
     //       Bar();
    //    }


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
            score = mainInfo.StatusBarModel.score;
            GUI.Label(new Rect(250, 150, 260, 20), score.ToString(), scorestyle);


        }
        else {

            score = mainInfo.Points.score;
            GUI.Label(new Rect(250, 150, 260, 20), score.ToString(), scorestyle);


        }

    }
       

    }

