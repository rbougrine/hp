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
    public Login login;
    public UIMan gui;

    void Start()
    {
        login = login.GetComponent<Login>();
        gui = gui.GetComponent<UIMan>();
    }

    void Awake()
    {
        DontDestroyOnLoad(this);

    }

    public UIMan GUI
    {
        get
        {
            return gui;
        }
    }

    public Login Login
    {
        get
        {
            return login;
        }
    }

    /*
    * Starts GUI elements if the condition is met.
    * Starts process in the statubarcontroller.
    */

    void OnGUI()
    {
        var CurrentMenu = login.CurrentMenu;
        if (CurrentMenu == null)
        {
            gui.Bar();
        }


    }

}


