using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StatusBar : MonoBehaviour
{
  
    public Login login;
    public UIMan gui;
  
    void Start()
    {
        login = login.GetComponent<Login>();
        gui = gui.GetComponent<UIMan>();
 
  
    }

    // Managing that the statusbar game object wont be destoyed so it can be used in the garage scene
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

    void OnGUI()
    {
        // set userinformation to statusbar after login completed
       
        var CurrentMenu = login.CurrentMenu;
        if (CurrentMenu == null)
        {
            gui.Bar();
        }


    }

}


