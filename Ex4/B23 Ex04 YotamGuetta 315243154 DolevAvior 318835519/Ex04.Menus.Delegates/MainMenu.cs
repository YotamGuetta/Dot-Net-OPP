using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private readonly MenuItem r_Menu;

        public MenuItem Menu 
        { 
            get 
            { 
                return r_Menu; 
            } 
        }

        public MainMenu()
        {
            r_Menu = new MenuItem("Main Menu")
            {
                FirstLevelMenu = true
            };
        }

        public void AddMenuItem(string i_Title, MenuItemClickHandler action)
        {
            MenuItem menuItem = new MenuItem(i_Title);
             menuItem.m_ClickInvoker +=
                 new MenuItemClickHandler(action);
            menuItem.m_ClickInvoker +=
                new MenuItemClickHandler(waitForInput);
            r_Menu.AddMenuItemToList(menuItem);
        }

        public void AddMenuItem(string i_Title, MainMenu action)
        {
            action.r_Menu.FirstLevelMenu = false;
            action.r_Menu.Title = i_Title;
            action.r_Menu.m_ClickInvoker +=
                new MenuItemClickHandler(action.Show);
            r_Menu.AddMenuItemToList(action.Menu);
        }

        private void waitForInput()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public void Show()
        {
            showMenuToUser();
        }

        private void showMenuToUser()
        {
            while (true)
            {
                int menusCounter = 1;
                Console.Clear();
                if (r_Menu.FirstLevelMenu)
                {
                    Console.WriteLine("Second Menu (Delegate Approach) - ");
                }

                Console.WriteLine(r_Menu.Title);
                Console.WriteLine("Choose an option:");
                foreach (MenuItem menu in r_Menu.SubMenus)
                {
                    Console.WriteLine(menusCounter + ") " + menu.Title);
                    menusCounter++;
                }

                if (r_Menu.FirstLevelMenu)
                {
                    Console.WriteLine("0) Exit");
                }
                else
                {
                    Console.WriteLine("0) Back");
                }

                string userInput = Console.ReadLine();
                try
                {
                    int menuIndex = int.Parse(userInput);
                    if (menuIndex <= r_Menu.SubMenus.Count && menuIndex >= 0)
                    {
                        if (menuIndex == 0)
                        {
                            return;
                        }

                        MenuItem choosenItem = r_Menu.SubMenus[menuIndex - 1];
                        choosenItem.Show();
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Not a number");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
            }
        }
    }
}
