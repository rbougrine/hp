using System;
using UnityEngine;


class ButtonManager : MonoBehaviour
{

    /// <summary>
    /// Created by Randa Bougrine
    /// Class that implements the interface IButton
    /// manages the buttons
    /// </summary>

    private ButtonFactory factory;
    private IButton chosenButton;
    private string buttonName;
    private GameObject usedObject;

    /// <summary>
    /// Used for initialization
    /// </summary>

    void Start()
    {
        factory = new ButtonFactory();
        buttonName = transform.name;
        chosenButton = factory.GetButton(buttonName);
        usedObject = GameObject.Find("GameInfo");
        GiveTexture();
    }

    /// <summary>
    /// Give GameObject wanted Texture
    /// </summary>

    void GiveTexture()
    {
        Texture buttonTexture = usedObject.GetComponent<ButtonTexture>().GetTexture(buttonName);
        GameObject.Find(buttonName).GetComponent<Renderer>().material.mainTexture = buttonTexture;
    }

    /// <summary>
    /// Calls the method ClickedOn from the chosen button
    /// </summary>

    public void ClickedOn()
    {
        chosenButton.ClickedOn();
    }
}
