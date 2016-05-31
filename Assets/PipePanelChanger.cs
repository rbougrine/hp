using UnityEngine;
using System.Collections;

public class PipePanelChanger : MonoBehaviour {


    public GameObject manager;
    public int originalStatus;
    public int currentStatus;

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
        if (currentStatus == 10)
            currentStatus = 0;
        else
            currentStatus++;
    }
    
   
}
