using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


/// <summary>
/// Interface that handles door interaction.
/// Implements the interface IDoor.
/// </summary>

public class Door : MonoBehaviour, IDoor
{

    //Public Variables
    public Animator animator;
    public GameObject Camera, AskBox, AskBoxFront;
    static RaycastHit hit;
    public string sceneName, Message;

    //Private Variables
    private MainInfo mainInfo;
    private Transform seenObject;
    private bool cameraLooking;
    private bool doorisClosed = true;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        mainInfo = new MainInfo();
    }

    /// <summary>
    /// Updates the camera raycast and the seenObject value.
    /// </summary>

    void Update()
    {
        cameraLooking = Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, Mathf.Infinity);
        seenObject = hit.collider.gameObject.transform;
    }

    /// <summary>
    /// Called when a Door object is clicked.
    /// Starts the door animation or another specific action.
    /// </summary>

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
        else
        {
            mainInfo.Login.Feedback = "Camera is not working correctly";
        }
    }

    /// <summary>
    /// Exits the game if the user confirms so.
    /// </summary>

    public void ExitGame()
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

    /// <summary>
    /// Teleports the player if he/she confirms.
    /// </summary>

    public void ToRoom()
    {
        if (SeenObject.name == "yes")
        {
            DoorTeleport();
        }
        else
        {
            AskBox.SetActive(false);
        }
    }

    /// <summary>
    /// Switches scenes from the garage to the house and vice versa.
    /// While changing the position of the camera to the saved position from the database.
    /// </summary>
    
    void DoorTeleport()
    {
        mainInfo.UserPosition.collectInfo();
        if (mainInfo.UserPosition.sceneName == "Game")
        {
            mainInfo.SwitchingScenes.LoadingScenes("Garage");
        }
        else
        {
            mainInfo.SwitchingScenes.LoadingScenes("Game");
        }
    }

    /// <summary>
    /// Opens and closes the door automatically.
    /// </summary>
    /// <returns>An IEnumerator value</returns>

    public IEnumerator DoorMovement()
    {
        if (CameraLooking)
        {
            if (doorisClosed == true)
            {
                if (SeenObject.parent.name == "Door_left")
                {
                    animator.Play("openDoor");
                    doorisClosed = false;
                    yield return new WaitForSeconds(5);
                    animator.Play("closeDoor");
                    doorisClosed = true;
                }
                else
                {
                    animator.Play("openDoorRight");
                    doorisClosed = false;
                    yield return new WaitForSeconds(5);
                    animator.Play("closeDoorRight");
                    doorisClosed = true;
                }
            }
        }
    }

    /// <summary>
    /// Getter for the CameraLooking boolean.
    /// </summary>

    public bool CameraLooking
    {
        get
        {
            return cameraLooking;
        }
    }

    /// <summary>
    /// Getter for the SeenObject Transform object.
    /// </summary>
    public Transform SeenObject
    {
        get
        {
            return seenObject;
        }
    }

}