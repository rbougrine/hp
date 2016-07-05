using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


/*
 * Created by Anny Aidinian.
 * 
 * Class that activates the statusBar
 *
 */


public class StatusBar : MonoBehaviour
{
    private MainInfo mainInfo;

    void Start()
    {
        mainInfo = new MainInfo();
      
    }

    void Awake()
    {
        

    }

    /*
    * Starts GUI elements if the condition is met.
    * Starts process in the statubarcontroller.
    */

    void OnGUI()
    {
        var CurrentMenu = mainInfo.Login.CurrentMenu;
        if (CurrentMenu == null)
        {
            mainInfo.GameUI.Bar();
        }


    }

}


