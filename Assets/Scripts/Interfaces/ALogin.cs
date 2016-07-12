using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Interfaces
{
    class ALogin : ILoginVariables
    {
        private string currentMenu;
        private string userName;
        

        public string CurrentMenu
        {
            get
            {
                return currentMenu;
            }

            set
            {
                currentMenu = value;        
            }
        }

        public string Username
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }
    }
}
