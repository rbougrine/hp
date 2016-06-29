using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;


public class MainInfo : MonoBehaviour
{

    private readonly string ip;
    private string url;
    private GameObject loginScript,userScript, door,statusBar, manager,uiMan, GoodJob, start, Point, timer, doneButton, timerbegin, uiManG;
    private LoginController controller;
    private SwitchingScenes switchingScenes;
    private UserPosition userPosition;
    private StatusBarModel statusBarModel;
    private Login login;
    private StartButton startButton;
    private PointCounter points;
    private Playedtime time;
    private PanelMan panelManager;
    private Door check;
    private DoneButton done;
    private ExerciseChanger changer;
    private UiManG garageGUI;
    private UIMan gameUI;
  

    public MainInfo()
    {
        loginScript = GameObject.Find("Login");
        userScript = GameObject.Find("UserPosition");
        statusBar = GameObject.Find("StatusBar");
        manager = GameObject.Find("Exercise");
        start = GameObject.Find("Start");
        door = GameObject.Find("Front_door");
        doneButton = GameObject.Find("Done");
        timerbegin = GameObject.Find("Timer");
        uiManG = GameObject.Find("UiManG");
        uiMan = GameObject.Find("UiMan");

        controller = loginScript.GetComponent<LoginController>();
        login = loginScript.GetComponent<Login>();
        switchingScenes = loginScript.GetComponent<SwitchingScenes>();  
        userPosition = userScript.GetComponent<UserPosition>();
        statusBarModel = statusBar.GetComponent<StatusBarModel>();
        startButton = start.GetComponent<StartButton>();
        panelManager = manager.GetComponent<PanelMan>();
        check = door.GetComponent<Door>();
        points = Point.GetComponent<PointCounter>();
        time = timer.GetComponent<Playedtime>();
        changer = manager.GetComponent<ExerciseChanger>();   
        done = doneButton.GetComponent<DoneButton>();
        garageGUI = uiManG.GetComponent<UiManG>();
        gameUI = uiMan.GetComponent<UIMan>();

        ip = "145.24.222.160";
        url = "http://" + ip + "/Unity_apply/controller.php";
    }

    public string IP
    {
        get
        {
            return ip;
        }

    }

    public string URL
    {
        get
        {
            return url;
        }

    }

    public LoginController Controller
    {
        get
        {
            return controller;
        }
    }

    public UIMan GameUI
    {
        get
        {
            return gameUI;
        }
    }


    public UiManG GarageGUI
    {
        get
        {
            return garageGUI;
        }
    }

    public SwitchingScenes SwitchingScenes
    {
        get
        {
            return switchingScenes;

        }
    }

    public StatusBarModel StatusBarModel
    {
        get
        {
            return statusBarModel;
        }


    }

    public Login Login
    {
        get
        {
            return login;
        }
    }

    public UserPosition UserPosition
    {
        get
        {
            return userPosition;
        }

    }


    public PointCounter Points
    {
        get
        {
            return points;

        }


    }


    public Playedtime Time
    {
        get
        {
            return time;

        }
    }


    public Door Door
    {
        get
        {
            return check;

        }


    }
    public StartButton StartButton
    {
        get
        {
            return startButton;

        }


    }
    public PanelMan PanelManager
    {
        get
        {
            return panelManager;

        }


    }

    public ExerciseChanger Changer
    {
        get
        {
            return changer;
        }
    }

    public DoneButton Done
    {
        get
        {
            return done;
        }
    }


    public Playedtime Timer
    {
        get
        {
            return time;

        }

    }

}