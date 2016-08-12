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
    private int buttonNumber;

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
                buttonNumber = 0;
                break;
            case "Done":
                chosenButton = factory.GetButton(ButtonType.Done);
                buttonNumber = 1;
                break;
            case "Cheat":
                chosenButton = factory.GetButton(ButtonType.Cheat);
                buttonNumber = 2;
                break;
            case "Yes":
                chosenButton = factory.GetButton(ButtonType.Yes);
                buttonNumber = 3;
                break;
            case "No":
                chosenButton = factory.GetButton(ButtonType.No);
                buttonNumber = 4;
                break;
            case "Stop":
                chosenButton = factory.GetButton(ButtonType.Stop);
                buttonNumber = 5;
                break;
            case "Next":
                chosenButton = factory.GetButton(ButtonType.Next);
                buttonNumber = 6;
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
        Texture texture = buttonTexture.GiveTexture(buttonName);
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
