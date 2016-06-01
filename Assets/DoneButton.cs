using UnityEngine;
using System.Collections;

public class DoneButton : MonoBehaviour
{
    private PanelMan panelManager;
    public int[] exerciseOne;
    public int[] ecxerciseTwo;
    public GameObject manager;

    // Use this for initialization
    void Start()
    {

        panelManager =  manager.GetComponent<PanelMan>();
        exerciseOne = new int[] { 3, 6,10, 6, 1, 8, 0, 0, 0, 8, 4, 6, 7, 6, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
       //exerciseTwo = new int[] { };
    }

    // Update is called once per frame
    void Update()
    {

    }
    public PanelMan PanelManager
    {
        get
        {
            return panelManager;

        }     


    }
    public void finalState()
    {
        PanelManager.readState();
        PanelManager.checkArray(PanelManager.userInput,exerciseOne);


        for (int i = 0; i<exerciseOne.Length; i++)
        {
           // Debug.Log(PanelManager.userInput[i]);

        }
    }


}
