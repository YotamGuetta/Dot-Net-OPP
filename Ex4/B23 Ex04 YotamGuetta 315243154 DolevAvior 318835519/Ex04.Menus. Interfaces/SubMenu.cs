using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class SubMenu : MenuItem, ISubMenu
    {
        private readonly List<MenuItem> m_SubMenusList;
        private bool m_IsFirstMenu;

        bool ISubMenu.IsFirstMenu
        {
            get 
            { 
                return m_IsFirstMenu; 
            }

            set 
            {
                m_IsFirstMenu = value; 
            }
        }

        public SubMenu(string i_Title) : base(i_Title)
        {
            m_IsFirstMenu = false;
            m_SubMenusList = new List<MenuItem>();
        }

        void ISubMenu.AddMenuItemToList(object i_menuItemToAdd)
        {
            m_SubMenusList.Add(i_menuItemToAdd as MenuItem);
        }

        public void MethodToExecuteWhenButtonWasClicked(MenuItem i_Button)
        {
            (i_Button as ISubMenu).Show();
        }

        void ISubMenu.Show()
        {
            while (true)
            {
                int menusCounter = 1;
                Console.Clear();
                if (m_IsFirstMenu) 
                {
                    Console.WriteLine("First Menu (Interface Approach) - ");
                }

                Console.WriteLine(Title);
                Console.WriteLine("Choose an option:");
                foreach (MenuItem menu in m_SubMenusList)
                {
                    Console.WriteLine(menusCounter + ") " + menu.Title);
                    menusCounter++;
                }

                if (m_IsFirstMenu)
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
                    if (menuIndex <= m_SubMenusList.Count && menuIndex >= 0)
                    {
                        if (menuIndex == 0)
                        {
                            return;
                        }

                        MenuItem choosenItem = m_SubMenusList[menuIndex - 1];
                        if (choosenItem is ISubMenu submenu)
                        {
                            submenu.Show();
                        }

                        if (choosenItem is IActiveItem activeItem)
                        {
                            activeItem.Invoke();
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                        }
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
