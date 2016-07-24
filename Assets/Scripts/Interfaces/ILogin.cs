/// <summary>
/// Interface that handles logging into the game.
/// </summary>

interface ILogin
{

    string CurrentMenu
    {
        get;
        set;
    }

    void LoginGUI();

    void CreateAccountGUI();

    void FeedbackGUI();

}