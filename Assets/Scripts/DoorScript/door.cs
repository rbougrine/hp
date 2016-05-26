using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    bool doorisClosed = true;
    public Animator anim;
    public GameObject Camera;
    public string sceneName;


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
            var ObjectParent = hit.collider.gameObject.transform.parent.name;
          
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
 