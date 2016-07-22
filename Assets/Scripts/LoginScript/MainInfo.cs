using UnityEngine;
using UnityEngine.SceneManagement;
using LitJson;
using System.IO;
using System.Configuration;
using System;
using System.Collections;
using System.Linq;

public class MainInfo : MonoBehaviour
    {
        private GameObject loginScript, userScript, score, door, statusBar, manager, GoodJob, start, Point, timer, doneButton;
        private LoginController controller;
        private SwitchingScenes switchingScenes;
        private UserPosition userPosition;
        private StatusBarModel statusBarModel;
        private Login login;
        private StartButton startButton;
        private PointCounter points;
        private PlayedTimeView time;
        private PanelMan panelManager;
        private Door check;
        private DoneButton done;
        private ExerciseChanger changer;
        private PlayedTimeView garageGUI;
        private StatusBarView gameUI;
        private PointerCounterModel pointerCounterModel;
        private PlayedtimeModel playedTimeModel;
        private DefaultGameInformation defaultGameInformation;
        private string jsonstring;
        private JsonData itemdata;
        

        public MainInfo()
        {
             loginScript = GameObject.Find("Login");
             login = loginScript.GetComponent<Login>();

             switchingScenes = loginScript.GetComponent<SwitchingScenes>();
             controller = loginScript.GetComponent<LoginController>();

            if (SceneManager.GetActiveScene().name != "Login")
            {
                userScript = GameObject.Find("UserPosition");
                statusBar = GameObject.Find("StatusBar");
                userPosition = userScript.GetComponent<UserPosition>();
                statusBarModel = statusBar.GetComponent<StatusBarModel>();
                InitializeScene();
            }

        }//End contructor

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


        void InitializeGame()
        {
            gameUI = GameObject.Find("StatusBar").GetComponent<StatusBarView>();

        }

        void InitializeGarage()
        {
            ObjectsGarage();
            startButton = start.GetComponent<StartButton>();
            panelManager = manager.GetComponent<PanelMan>();
            check = door.GetComponent<Door>();
            points = score.GetComponent<PointCounter>();
            changer = manager.GetComponent<ExerciseChanger>();
            done = doneButton.GetComponent<DoneButton>();
            garageGUI = timer.GetComponent<PlayedTimeView>();
            pointerCounterModel = score.GetComponent<PointerCounterModel>();
            playedTimeModel = timer.GetComponent<PlayedtimeModel>();
        }


        void ObjectsGarage()
        {
            score = GameObject.Find("Score");
            manager = GameObject.Find("Exercise");
            start = GameObject.Find("Start");
            door = GameObject.Find("Front_door");
            doneButton = GameObject.Find("Done");
            timer = GameObject.Find("Timer");

        }

        public LoginController Controller
        {
            get
            {
                return controller;
            }
        }

        public StatusBarView GameUI
        {
            get
            {
                return gameUI;
            }
        }


        public PlayedTimeView GarageGUI
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


        public PlayedtimeModel Time
        {
            get
            {
                return playedTimeModel;

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




        public PlayedtimeModel PlaytimeModel
        {
            get
            {
                return playedTimeModel;

            }

        }

        public PointerCounterModel PointerCounterModel
        {
            get
            {
                return pointerCounterModel;
            }
        }
    }