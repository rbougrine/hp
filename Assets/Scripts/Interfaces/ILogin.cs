using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.LoginScript
{
    interface ILogin
    {
        string CurrentMenu
        {
            get;
            set;
        }

        void LoggedIn();

        void LoginGUI();

        void CreateAccountGUI();

        void FeedbackGUI();
    }
}
