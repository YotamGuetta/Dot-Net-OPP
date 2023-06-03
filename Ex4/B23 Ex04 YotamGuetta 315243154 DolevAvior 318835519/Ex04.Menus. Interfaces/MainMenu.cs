using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private readonly ISubMenu r_ThisMenu;

        public ISubMenu ThisMenu 
        { 
            get 
            { 
                return r_ThisMenu; 
            } 
        }

        public MainMenu()
        {
            r_ThisMenu = new SubMenu("Main Menu");
            ThisMenu.IsFirstMenu = true;
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            r_ThisMenu.AddMenuItemToList(i_MenuItem);
        }

        public void Show()
        {
            r_ThisMenu.Show();
        }
    }
}
