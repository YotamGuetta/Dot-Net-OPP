using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Delegates;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            Interfaces.MainMenu mainMenuInterface = new Interfaces.MainMenu();

            Interfaces.ISubMenu subMenu1Interface = new Interfaces.SubMenu("Time/Date Show");
            subMenu1Interface.AddMenuItemToList(new Interfaces.ActionItem("Date Show", () => DisplayDate()));
            subMenu1Interface.AddMenuItemToList(new Interfaces.ActionItem("Time Show", () => DisplayTime()));

            Interfaces.ISubMenu subMenu2Interface = new Interfaces.SubMenu("Spaces and Version");
            subMenu2Interface.AddMenuItemToList(new Interfaces.ActionItem("Show Version", () => DisplayVersion()));
            subMenu2Interface.AddMenuItemToList(new Interfaces.ActionItem("Count Spaces", () => CountSpaces()));

            mainMenuInterface.AddMenuItem(subMenu1Interface as SubMenu);
            mainMenuInterface.AddMenuItem(subMenu2Interface as SubMenu);

            Delegates.MainMenu mainMenuDelegate = new Delegates.MainMenu();

            Delegates.MainMenu subMenu1Delegate = new Delegates.MainMenu();
            subMenu1Delegate.AddMenuItem("Date Show", new MenuItemClickHandler(DisplayDate));
            subMenu1Delegate.AddMenuItem("Time Show", DisplayTime);

            Delegates.MainMenu subMenu2Delegate = new Delegates.MainMenu();
            subMenu2Delegate.AddMenuItem("Show Version", DisplayVersion);
            subMenu2Delegate.AddMenuItem("Count Spaces", CountSpaces);

            mainMenuDelegate.AddMenuItem("Time/Date Show", subMenu1Delegate);
            mainMenuDelegate.AddMenuItem("Spaces and Version", subMenu2Delegate);

            mainMenuInterface.Show();
            
            mainMenuDelegate.Show();
        }

        public static void DisplayDate()
        {
            Console.WriteLine("Today's date is - " + DateTime.Now.ToShortDateString());
        }

        public static void DisplayTime()
        {
            Console.WriteLine("Current time is - " + DateTime.Now.ToShortTimeString());
        }

        public static void DisplayVersion()
        {
            Console.WriteLine("Version: 23.2.4.9805");
        }

        public static void CountSpaces()
        {
            Console.WriteLine("Enter a sentence - ");
            string sentence = Console.ReadLine();
            int spaceCount = sentence.Split(' ').Length - 1;
            Console.WriteLine("Number of spaces - " + spaceCount);
        }
    }
}
