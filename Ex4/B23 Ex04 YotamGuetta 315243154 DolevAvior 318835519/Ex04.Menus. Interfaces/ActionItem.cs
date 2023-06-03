using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class ActionItem : MenuItem, IActiveItem
    {
        private readonly Action r_ItemAction;

        public ActionItem(string i_Title, Action i_Action) : base(i_Title)
        {
            r_ItemAction = i_Action;
        }

        public void Invoke()
        {
            r_ItemAction.Invoke();
        }
    }
}
