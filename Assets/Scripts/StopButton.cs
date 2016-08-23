using UnityEngine;

class StopButton : IButton
{

    /// <summary>
    /// Created by Randa Bougrine
    /// Class that implements the interface IButton
    /// manages the stop button
    /// </summary>

    private string stopParent;

    /// <summary>
    /// Put the GameObject that is clicked on inactive
    /// it won't be visible in the scene anymore
    /// </summary>

    public void ClickedOn()
    {
        stopParent = GameObject.Find("Stop").transform.parent.name;
        GameObject.Find(stopParent).SetActive(false);
    }
}

