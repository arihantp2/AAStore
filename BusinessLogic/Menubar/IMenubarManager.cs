using System;
using AAStore.API.Model;

namespace AAStore.API.BusinessLogic.Menubar
{
    public interface IMenubarManager
    {
        List<MenubarModel> GetMenu();
        public bool AddMenu(MenubarModel menu);
    }
}