using System;
using System.Collections.Generic;

namespace Ex04.Menus.Delegates
{
    public delegate void MenuItemClickHandler();

    public class MenuItem
    {
        public event MenuItemClickHandler m_ClickInvoker;

        private readonly List<MenuItem> r_SubMenus;

        public List<MenuItem> SubMenus 
        { 
            get 
            { 
                return r_SubMenus; 
            } 
        }

        private bool m_FirstLevelMenu = false;

        public bool FirstLevelMenu 
        { 
            get 
            { 
                return m_FirstLevelMenu; 
            }
            
            set 
            { 
                m_FirstLevelMenu = value; 
            } 
        }

        private string m_Title;

        public string Title 
        { 
            get 
            { 
                return m_Title; 
            } 

            set 
            { 
                m_Title = value; 
            } 
        }

        public MenuItem(string title)
        {
            m_Title = title;
            r_SubMenus = new List<MenuItem>();
        }

        public void AddMenuItemToList(MenuItem i_menuItemToAdd)
        {
            r_SubMenus.Add(i_menuItemToAdd);
        }

        public void Show() 
        {
            OnClicked();
        }

        protected virtual void OnClicked()
        {
            m_ClickInvoker?.Invoke();
        }
    }
}