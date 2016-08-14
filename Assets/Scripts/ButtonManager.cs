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
        ChosenButton(buttonName);
        GiveTexture("GameInfo");
    }

    /// <summary>
    /// Handles which button to be made
    /// </summary>
    /// <param name="name">Given the Name of the button</param>

    void ChosenButton(string name)
    {
        switch (name)
        {
            case "Start":
                chosenButton = factory.GetButton(ButtonType.Start);
                break;
            case "Done":
                chosenButton = factory.GetButton(ButtonType.Done);
                break;
            case "Cheat":
                chosenButton = factory.GetButton(ButtonType.Cheat);
                break;
            case "Yes":
                chosenButton = factory.GetButton(ButtonType.Yes);
                break;
            case "No":
                chosenButton = factory.GetButton(ButtonType.No);
                break;
            case "Stop":
                chosenButton = factory.GetButton(ButtonType.Stop);
                break;
            case "Next":
                chosenButton = factory.GetButton(ButtonType.Next);
                break;
            default:
                throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Give GameObject wanted Texture
    /// </summary>

    void GiveTexture(string objectName)
    {
        usedObject = GameObject.Find(objectName);
        ButtonTexture buttonTexture = usedObject.GetComponent<ButtonTexture>();
        Texture texture = buttonTexture.GetTexture(buttonName);
        GameObject.Find(buttonName).GetComponent<Renderer>().material.mainTexture = texture;
    }

    /// <summary>
    /// Calls the method ClickedOn from the chosen button
    /// </summary>

    public void ClickedOn()
    {
        chosenButton.ClickedOn();
    }
}
