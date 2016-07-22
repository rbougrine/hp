/// <summary>
/// Interface that represents the status bar.
/// </summary>

interface IBar
{

    int Score
    {
        get;
        set;
    }

    void Bar();

    void TimerDisplay();

}