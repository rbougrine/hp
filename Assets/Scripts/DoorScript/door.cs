using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
   //public variable
    public Animator anim;
    public GameObject Camera, AskBox, AskBoxFront;
    public string sceneName, Message;
    static RaycastHit hit;

    //private variable
    private bool cameraLooking;
    private Transform seenObject;
    private bool doorisClosed = true;
    private GameObject loginObject, userPositionScript;
    private SwitchingScenes switchingScenes;
    private UserPosition userPosition;
    private Login login;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
       loginObject = GameObject.Find("Login");
       login = loginObject.GetComponent<Login>();
       switchingScenes = loginObject.GetComponent<SwitchingScenes>();
       userPositionScript = GameObject.Find("UserPosition");
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

    public SwitchingScenes SwitchingScenes
    {
        get
        {
            return switchingScenes;

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
    public void ClickedOnDoor()
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
                     StartCoroutine(DoorMovement());
                }
        }
    }

    public void exitGame()
    {
        if (SeenObject.name == "yes")
        {
            LoginScript.logged = false;
            SceneManager.LoadScene("Login");
            
        }
        else
        {
             AskBoxFront.SetActive(false);
        }
    }

    public void toRoom()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            SwitchingScenes.LoadingScenes("Garage");
        }
        else
            Debug.Log(SeenObject.name);
        if (SeenObject.name == "yes")
        {
          DoorTeleport();
        }
        else
        {
            Debug.Log(SeenObject.name);
            AskBox.SetActive(false);
        }

   }

    //Switching between garage and house
    //while changing the position of the camera to the saved position from the database
    void DoorTeleport()
    {
       
        UserPosition.collectInfo();
     
        if (UserPosition.sceneName == "Game")
        {
            Debug.Log("Switching scenes to garage");

            SwitchingScenes.LoadingScenes("Garage");
           
        }
        else
        {
           Debug.Log("Switching scenes to game");
        
          SwitchingScenes.LoadingScenes("Game");

            
        }         
   
     }
     //Opening and closing the doors
    IEnumerator DoorMovement()
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
