using UnityEngine;
using UnityEngine.SceneManagement;
using LitJson;


public class MainInfo : MonoBehaviour
{
    /// <summary>
    /// Created by Randa Bougrine & Anny Aidinian
    /// Class initializes every game object of the game
    /// other classes will use this to get the wanted classes
    /// that are attached to the different GameObjects
    /// </summary>

    private string jsonstring;
    private JsonData itemdata;
    private GameObject loginScript, userScript, score, front_door, statusBar, question, GoodJob, gameInfo, Point, timer, done, puzzle;
    private LoginController loginController;
    private SwitchingScenes switchingScenes;
    private UserPosition userPosition;
    private StatusBarModel statusBarModel;
    private Login login;
    private Exercise exercise;
    private PointCounter pointCounter;
    private PanelManager panelManager;
    private Door door;
    private ExerciseChanger exerciseChanger;
    private PlayedTimeView garageGUI;
    private StatusBarView gameUI;
    private PointerCounterModel pointerCounterModel;
    private PlayedtimeModel playedTimeModel;
    private DefaultGameInformation defaultGameInformation;
    

    /// <summary>
    /// Initializes the gameObjects of the first scene loaded
    /// when it's another scene then it will call methode InitializeScene()
    /// </summary>

    void Start()
    {
        loginScript = GameObject.Find("Login");

        login = loginScript.GetComponent<Login>();
        switchingScenes = loginScript.GetComponent<SwitchingScenes>();
        loginController = loginScript.GetComponent<LoginController>();

        if (SceneManager.GetActiveScene().name != "Login")
        {
            userScript = GameObject.Find("UserPosition");
            statusBar = GameObject.Find("StatusBar");
            userPosition = userScript.GetComponent<UserPosition>();
            statusBarModel = statusBar.GetComponent<StatusBarModel>();
            InitializeScene();
        }
    }

    /// <summary>
    /// Method that will decide which methode to call
    /// depending on the scene that is active at the moment
    /// </summary>

    void InitializeScene()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            InitializeGame();
        }
        else if (SceneManager.GetActiveScene().name == "Garage")
        {
            InitializeGarage();
        }
        else
        {
            Login.Feedback = "World is not found.";
        }
    }

    /// <summary>
    /// Method that initialize the GameObjects needed for the scene Game
    /// </summary>

    void InitializeGame()
    {
        gameUI = statusBar.GetComponent<StatusBarView>();

    }

    /// <summary>
    /// Method that initialize the GameObjects needed for the scene Game
    /// </summary>
    void ObjectsGame()
    {
    }

    /// <summary>
    /// Method that initialize the GameObjects components needed for the scene Garage
    /// </summary>

    void InitializeGarage()
    {
        ObjectsGarage();
        exercise = gameInfo.GetComponent<Exercise>();
        panelManager = puzzle.GetComponent<PanelManager>();
        door = front_door.GetComponent<Door>();
        pointCounter = score.GetComponent<PointCounter>();
        exerciseChanger = question.GetComponent<ExerciseChanger>();
        garageGUI = timer.GetComponent<PlayedTimeView>();
        pointerCounterModel = score.GetComponent<PointerCounterModel>();
        playedTimeModel = timer.GetComponent<PlayedtimeModel>();
    }

    /// <summary>
    /// Method that initialize the GameObjects needed for the scene Garage
    /// </summary>

    void ObjectsGarage()
    {
        score = GameObject.Find("Score");
        question = GameObject.Find("Question");
        gameInfo = GameObject.Find("GameInfo");
        front_door = GameObject.Find("Front_door");
        timer = GameObject.Find("Timer");
        puzzle = GameObject.Find("PuzzelScreen");

    }

    /// <summary>
    /// Getter for LoginController
    /// </summary>

    public LoginController LoginController
    {
        get
        {
            return loginController;
        }
    }

    /// <summary>
    /// Getter for StatusBarView
    /// </summary>

    public StatusBarView GameUI
    {
        get
        {
            return gameUI;
        }
    }

    /// <summary>
    /// Getter for PlayedTimeView
    /// </summary>

    public PlayedTimeView GarageGUI
    {
        get
        {
            return garageGUI;
        }
    }

    /// <summary>
    /// Getter for SwitchingScenes
    /// </summary>


    public SwitchingScenes SwitchingScenes
    {
        get
        {
            return switchingScenes;

        }
    }

    /// <summary>
    /// Getter for StatusBarModel
    /// </summary>

    public StatusBarModel StatusBarModel
    {
        get
        {
            return statusBarModel;
        }


    }

    /// <summary>
    /// Getter for Login
    /// </summary>


    public Login Login
    {
        get
        {
            return login;
        }
    }

    /// <summary>
    /// Getter for UserPosition
    /// </summary>

    public UserPosition UserPosition
    {
        get
        {
            return userPosition;
        }

    }

    /// <summary>
    /// Getter for PointCounter
    /// </summary>

    public PointCounter PointCounter
    {
        get
        {
            return pointCounter;

        }


    }

    /// <summary>
    /// Getter for PlayedtimeModel
    /// </summary>

    public PlayedtimeModel PlayedtimeModel
    {
        get
        {
            return playedTimeModel;

        }
    }

    /// <summary>
    /// Getter for Door
    /// </summary>

    public Door Door
    {
        get
        {
            return door;

        }

    }

    /// <summary>
    /// Getter for StartButton
    /// </summary>

    public Exercise Exercise
    {
        get
        {
            return exercise;

        }


    }

    /// <summary>
    /// Getter for PanelManager
    /// </summary>

    public PanelManager PanelManager
    {
        get
        {
            return panelManager;

        }


    }

    /// <summary>
    /// Getter for ExerciseChanger
    /// </summary>

    public ExerciseChanger ExerciseChanger
    {
        get
        {
            return exerciseChanger;
        }
    }

    /// <summary>
    /// Getter for PlayedtimeModel
    /// </summary>

    public PlayedtimeModel PlaytimeModel
    {
        get
        {
            return playedTimeModel;

        }

    }

    /// <summary>
    /// Getter for PointerCounterModel
    /// </summary>

    public PointerCounterModel PointerCounterModel
    {
        get
        {
            return pointerCounterModel;
        }
    }
}