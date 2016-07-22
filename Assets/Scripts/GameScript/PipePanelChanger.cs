using UnityEngine;
using System.Collections;

public class PipePanelChanger : MonoBehaviour
{
    /// <summary>
    /// Created by Randa Bougrine & Anny Aidinian.
    /// Manages changing of puzzel part when cliced on one 
    /// </summary>

    public GameObject manager;
    public int originalStatus, currentStatus;

    /// <summary>
    /// Update is called once per frame
    /// </summary>

    void Update()
    {
        Texture texture = manager.GetComponent<PanelMan>().GiveTexture(currentStatus);
        GetComponent<Renderer>().material.mainTexture = texture;
    }

    /// <summary>
    /// Add the mouse count
    /// </summary>

    public void OnMouseClick()
    {
        if (currentStatus == 17)
            currentStatus = 0;
        else
            currentStatus++;
    }


}
