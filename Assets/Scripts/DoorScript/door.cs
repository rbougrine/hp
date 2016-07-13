using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Scripts.DoorScript;

public class Door : MonoBehaviour, IDoor
{
   //public variable
    public Animator anim;
    public GameObject Camera, AskBox, AskBoxFront;
    public string sceneName, Message;
    static RaycastHit hit;

    //private variable
    private bool cameraLooking;
    private MainInfo mainInfo;
    private Transform seenObject;
    private bool doorisClosed = true;
  

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        mainInfo = new MainInfo();
    }

    void Update()
    {
        cameraLooking = Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, Mathf.Infinity);
        seenObject = hit.collider.gameObject.transform;
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
            mainInfo.Login.logged = false;
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
            mainInfo.SwitchingScenes.LoadingScenes("Garage");
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
   // while changing the position of the camera to the saved position from the database
    void DoorTeleport()
    {

        mainInfo.UserPosition.collectInfo();
     
        if (mainInfo.UserPosition.sceneName == "Game")
        {
            Debug.Log("Switching scenes to garage");

            mainInfo.SwitchingScenes.LoadingScenes("Garage");
           
        }
        else
        {
           Debug.Log("Switching scenes to game");

            mainInfo.SwitchingScenes.LoadingScenes("Game");

            
        }         
   
     }
     //Opening and closing the doors
   public IEnumerator DoorMovement()
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
