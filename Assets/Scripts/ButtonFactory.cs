using System;

public class ButtonFactory
{
    /// <summary>
    /// Created by Randa Bougrine
    /// Implementation of Factory 
    /// </summary>

    /// <summary>
    /// Used to create objects
    /// </summary>
    public IButton GetButton(string buttonType)
    {
        switch (buttonType)
        {
            case "Start":
                return new StartButton();
            case "Done":
                return new DoneButton();
            case "Cheat":
                return new CheatButton();
            case "Yes":
                return new YesButton();
            case "No":
                return new NoButton();
            case "Stop":
                return new StopButton();
            case "Next":
                return new NextButton();
            default:
                throw new NotSupportedException(string.Format("Button '{0}' cannot be created", buttonType));
        }
    }
}

