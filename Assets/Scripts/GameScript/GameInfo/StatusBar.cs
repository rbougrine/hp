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
    private Login login;
    private GameObject loginScript, guiScript;
    private UIMan gui;

    void Start()
    {       
            loginScript = GameObject.Find("Login");
            guiScript = GameObject.Find("UiMan");

            login = loginScript.GetComponent<Login>();
            gui = guiScript.GetComponent<UIMan>();
      
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
        var CurrentMenu = Login.CurrentMenu;
        if (CurrentMenu == null)
        {
            GUI.Bar();
        }


    }

}


