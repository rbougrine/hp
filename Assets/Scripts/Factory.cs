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
    public IButton GetButton(ButtonType type)
    {
        switch (type)
        {
            case ButtonType.Start:
                return new StartButton();
            case ButtonType.Done:
                return new DoneButton();
            case ButtonType.Cheat:
                return new CheatButton();
            case ButtonType.Yes:
                return new YesButton();
            case ButtonType.No:
                return new NoButton();
            case ButtonType.Stop:
                return new StopButton();
            case ButtonType.Next:
                return new NextButton();
            default:
                throw new NotSupportedException();
        }
    }
}

