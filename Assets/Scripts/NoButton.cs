using UnityEngine;

class NoButton : IButton
{
    /// <summary>
    /// Created by Randa Bougrine
    /// Class that implements the interface IButton
    /// The no button in the game makes gameObjects invisible
    /// </summary>

    private string noParent;

    /// <summary>
    /// Put the GameObject that is clicked on inactive
    /// it won't be visible in the scene anymore
    /// </summary>

    public void ClickedOn()
    {
        noParent = GameObject.Find("No").transform.parent.name;
        GameObject.Find(noParent).SetActive(false);
    }
}

