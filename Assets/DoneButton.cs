using UnityEngine;
using System.Collections;

public class DoneButton : MonoBehaviour
{
    public GameObject manager;
  
    
    
    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void finalState()
    {
        PanelMan Panelman = manager.GetComponent<PanelMan>();
        Panelman.readState();


        
    }


}
