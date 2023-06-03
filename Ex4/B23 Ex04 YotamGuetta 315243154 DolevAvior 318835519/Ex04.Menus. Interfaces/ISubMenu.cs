namespace Ex04.Menus.Interfaces
{
    public interface ISubMenu
    {
        bool IsFirstMenu { get; set; }

        void Show();

        void AddMenuItemToList(object i_menuItemToAdd);
    }
}
