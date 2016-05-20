using UnityEngine;
using System.Collections;

public class door : MonoBehaviour
{
    public bool doorisClosed;
    public Animator anim;

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
		Debug.Log ("binne");


    }
    IEnumerator doorMovement()
    {
        if (doorisClosed == true)
        {
            anim.Play("openDoor");
            doorisClosed = false;
            yield return new WaitForSeconds(5);
            anim.Play("closeDoor");
            doorisClosed = true;
        }

    }
}   
 