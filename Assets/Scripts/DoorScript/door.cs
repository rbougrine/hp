using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    bool doorisClosed = true;
    public Animator anim;
    public GameObject Camera;
    public GameObject AskBox;
    public GameObject AskBoxFront;
    public string sceneName,Message;
    static RaycastHit hit;
    private bool cameraLooking;
    private Transform seenObject;
    private GameObject loginScript;
    private Login login;
    private GameObject userPositionScript;
    private UserPosition userPosition;
   

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        loginScript = GameObject.Find("Login");
        login = loginScript.GetComponent<Login>();
        userPositionScript = GameObject.Find("CameraPosition");
        userPosition = userPositionScript.GetComponent<UserPosition>();
    }

    void Update()
    {
        cameraLooking = Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, Mathf.Infinity);
        seenObject = hit.collider.gameObject.transform;
    }
        
    public UserPosition UserPosition
    {
        get
        {
            return userPosition;

        }

    }

    public Login LoginScript
    {
        get
        {
            return login;

        }

    }

   public bool CameraLooking
    {
        get
        {
            return cameraLooking;
        }
    }


  public Transform SeenObject
    { 
        get
        {
            return seenObject;
        }
    }

    //method called when clicked on a door
    public void clickedOnDoor()
    {
      
        if (CameraLooking)
        {
              
            if (SeenObject.parent.name == "Front_door")
            {
                AskBoxFront.SetActive(true);
            }
            else if (SeenObject.parent.name == "Back_door")
            {
                AskBox.SetActive(true);
            }
             else
                {
                     StartCoroutine(doorMovement());
                }
        }
    }

    public void exitGame()
    {
        if (SeenObject.name == "yes")
        {
            LoginScript.camera1.SetActive(true);
            LoginScript.camera2.SetActive(false);
            LoginScript.loggedIn = false;
            LoginScript.CurrentMenu = "Login";
            
        }
        else
        {
            Debug.Log(LoginScript.loggedIn+"loggedIn");
            AskBoxFront.SetActive(false);
        }
    }

    public void toRoom()
    {
        if (SeenObject.name == "yes")
        {
            doorTeleport();
        }
        else
        {
            AskBox.SetActive(false);
        }

   }

    //Switching between garage and house
    //while changing the position of the camera to the saved position from the database
    void doorTeleport()
    {
      
        UserPosition.collectInfo(); 
               
        if (UserPosition.sceneName == "Game")
        {
            Debug.Log("Switching scenes to garage");

            LoginScript.loadingScenes("Garage");
           
        }
        else
        {
           Debug.Log("Switching scenes to game");

            LoginScript.loadingScenes("Game");

            
        }
  
            
   
     }
  
    //Opening and closing the doors
    IEnumerator doorMovement()
    {    

        if (CameraLooking)
        {
          
            if (doorisClosed == true)
            {
                if (SeenObject.parent.name == "Door_left")
                {

                    anim.Play("openDoor");
                    doorisClosed = false;
                    yield return new WaitForSeconds(5);
                    anim.Play("closeDoor");
                    doorisClosed = true;

                }
                else
                {
                    anim.Play("openDoorRight");
                    doorisClosed = false;
                    yield return new WaitForSeconds(5);
                    anim.Play("closeDoorRight");
                    doorisClosed = true;

                }
            }
            else
            {
                Debug.Log("Can't open a door thats already open");

            }
          
        }
    }

 
}
