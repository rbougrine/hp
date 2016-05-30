using UnityEngine;
using System.Collections;

public class PipeCheck : MonoBehaviour
{

    string clickedObject;
    public GameObject Camera;
    GameObject CardboardReticle;


    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void chosenObject()
    {
        RaycastHit hit;
        CardboardReticle = GameObject.Find("CardboardMain/Head/Main Camera/CardboardReticle");
        
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, Mathf.Infinity))
        {
            clickedObject = hit.collider.gameObject.transform.name;
            CardboardReticle.SetActive(false);

            var chosenObject = GameObject.Find("CardboardMain/Head/Main Camera/Carrying/"+clickedObject);
            chosenObject.SetActive(true);
           
        }
    }

    void placeObject()
    {




    }




}