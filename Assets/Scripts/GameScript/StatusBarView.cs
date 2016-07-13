using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Scripts.Interfaces;

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
    private ALogin AbstractLogin;
    private AGarage AbstractGarage;



    void Start()
    {

        mainInfo = new MainInfo();
        AbstractLogin = new ALogin();
        AbstractGarage = new AGarage();
    }




    void OnGUI()
    {
    
        var CurrentMenu = AbstractLogin.CurrentMenu;

        Debug.Log(AbstractLogin.CurrentMenu);
        if (CurrentMenu == null)
        {
         
          
            Bar();
         
        }


    }

    /*
     * Draws the GUI of the statusbar with userinformation.
     * Whichever condition is met, the score is fetches from other classes.
    */


    public void Bar()
    {
        InfoStatusbar = mainInfo.StatusBarModel.InfoStatusbar;
        GUI.Box(new Rect(250, 150, 260, 20), InfoStatusbar, labelStyle);

        if (SceneManager.GetActiveScene().name == "Game")

        {
            score = AbstractGarage.Score;
            GUI.Label(new Rect(250, 150, 260, 20), score.ToString(), scorestyle);


        }
        else {

            score = mainInfo.Points.score;
            GUI.Label(new Rect(250, 150, 260, 20), score.ToString(), scorestyle);


        }

    }


}

