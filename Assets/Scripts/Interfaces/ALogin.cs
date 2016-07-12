using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Interfaces
{
    class ALogin : ILoginVariables
    {
        private string currentMenu;
     
        // Constructor:
        public ALogin(string menu)
        {
            currentMenu = menu;  
        }

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
    }
}
