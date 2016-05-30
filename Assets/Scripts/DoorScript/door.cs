using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    bool doorisClosed = true;
    public Animator anim;
    public GameObject Camera;
    public string sceneName,Message;
    static RaycastHit hit;
    private bool cameraLooking;
    private string seenObject;


    void Awake()
    {
        anim = GetComponent<Animator>();
        
    }

    void Start()
    {
     
    }

    void Update()
    {
        cameraLooking = Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, Mathf.Infinity);
        seenObject = hit.collider.gameObject.transform.parent.name;
    }

    //Door mechanisme
    void OnGUI()
    {

        if (Message == "quitGame")
        {
            quitGame();
        }
        else if (Message == "toGarage")
        {
            toGarage();
        }
        
    }
   
   public bool CameraLooking
    {
        get
        {
            return cameraLooking;
        }
    }

  public string SeenObject
    { 
        get
        {
            return seenObject;
        }
    }

    public void clickedOnDoor()
    {    
       
        if (CameraLooking)
        {
                     
            if (SeenObject == "Front_door")
            {
                Message = "quitGame";
            }
            else if (SeenObject == "Back_door")
            {
                Message = "toGarage";
            }
             else
                {
                     StartCoroutine(doorMovement());
                }
        }
    }

    void quitGame()
    {
        GameObject LoginScript = GameObject.Find("Login");
        Login Login = LoginScript.GetComponent<Login>();


        GUI.Box(new Rect(262, 86, 334, 121), "Are you sure you want to quit the game?");

        if (GUI.Button(new Rect(291, 162, 111, 25), "Yes"))
            {
                Message = null;

                Login.CurrentMenu = "Login";            
                Login.camera1.SetActive(true);
                Login.camera2.SetActive(false);

            }
            else if (GUI.Button(new Rect(467, 162, 111, 25), "No"))
            {
                Message = null;
            }
               
    }

    void toGarage()
    {
         GUI.Box(new Rect(235, 55, 225, 222), "Do you want to enter the garage?");

        if (GUI.Button(new Rect(242, 223, 111, 25), "Yes"))
        {                    
            Message = null;
            doorTeleport();
           
        }
        else if (GUI.Button(new Rect(357, 223, 90, 25), "No"))
        {
            Message = null;
        }
   }

    //Switching between garage and house
    //while changing the position of the camera to the saved position from the database
    void doorTeleport()
    {
        GameObject positionScript = GameObject.Find("CameraPosition");
        UserPosition UserPosition = positionScript.GetComponent<UserPosition>();

        UserPosition.collectInfo();
        
        if (UserPosition.sceneName == "Game")
        {
            Debug.Log("Switching scenes");
            SceneManager.LoadScene("Garage");
            UserPosition.changeCameraPosition();
        }
        else
        {
            SceneManager.LoadScene("Game");
            UserPosition.changeCameraPosition();
        }    
   
     }
   
    //Opening and closing the doors
    IEnumerator doorMovement()
    {    

        if (CameraLooking)
        {
          
            if (doorisClosed == true)
            {
                Debug.Log(SeenObject);
                if (SeenObject == "Door_left")
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
