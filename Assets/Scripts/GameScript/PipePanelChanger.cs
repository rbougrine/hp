using UnityEngine;
using System.Collections;

public class PipePanelChanger : MonoBehaviour
{


    /*
    * Created by Randa Bougrine & Anny Aidinian.
    * 
    * Manages changing of puzzel part when cliced on one 
    * 
    */

    public GameObject manager;
    public int originalStatus, currentStatus;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Texture texture = manager.GetComponent<PanelMan>().GiveTexture(currentStatus);
        GetComponent<Renderer>().material.mainTexture = texture;
    }



    public void OnMouseClick()
    {
        if (currentStatus == 17)
            currentStatus = 0;
        else
            currentStatus++;
    }


}
