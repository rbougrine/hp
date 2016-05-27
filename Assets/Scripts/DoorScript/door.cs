using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    bool doorisClosed = true;
    public Animator anim;
    public GameObject Camera;
    public string sceneName;
    bool closeMessage = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void doorAction()
    {

        StartCoroutine(doorMovement());

    }

   public void OnGUI()
    {
        GameObject LoginScript = GameObject.Find("Login");
        Login Login = LoginScript.GetComponent<Login>();

      //  closeMessage = true;

        if (closeMessage)
        {
            GUI.Box(new Rect(235, 55, 225, 222), "Are you sure you want to quit the game?");
            if (GUI.Button(new Rect(242, 223, 111, 25), "Yes"))
            {
              
                Login.CurrentMenu = "Login";
                closeMessage = false;
                Login.camera1.SetActive(true);
                Login.camera2.SetActive(false);
              
            }
            else if (GUI.Button(new Rect(357, 223, 90, 25), "No"))
            {
                closeMessage = false;
            }

        }

    }

    //Switching between garage and house
    public void doorTeleport()
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
   

    IEnumerator doorMovement()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, Mathf.Infinity))
        {
            var ObjectParent = hit.collider.gameObject.transform.parent.parent.name;
          
            if(ObjectParent == "Door_left")
                {
                  
                    anim.Play("openDoor");
                    doorisClosed = false;
                    yield return new WaitForSeconds(5);
                    anim.Play("closeDoor");
                    doorisClosed = true;
                            
            }else
                {
                    anim.Play("openDoorRight");
                    doorisClosed = false;
                    yield return new WaitForSeconds(5);
                    anim.Play("closeDoorRight");
                    doorisClosed = true;
      
            }

          
        }
    }

 
}
 