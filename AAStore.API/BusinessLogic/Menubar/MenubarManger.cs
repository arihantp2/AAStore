using System;
using System.Collections.Generic;
using System.Data;
using AAStore.API.Model;
using AAStore.API.Repository.Menubar;

namespace AAStore.API.BusinessLogic.Menubar
{
    public class MenubarManager : IMenubarManager
    {
        private readonly IMenubarRepository _menubarRepository;
        public MenubarManager(IMenubarRepository menubarRepository)
        {
            _menubarRepository = menubarRepository;
        }

        public List<MenubarModel> GetMenu()
        {
            DataSet DS = new DataSet();
            List<MenubarModel> list = new List<MenubarModel>();

            DS = _menubarRepository.GetMenu();
            if(DS != null)
            {
                DataTable dt = DS.Tables[0];
                if(dt != null && dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        MenubarModel data = new MenubarModel();

                        data.MenuName = dr["MenuName"].ToString();
                        list.Add(data);
                    }
                }
            }
            return list;
        }

        public bool AddMenu(MenubarModel menu)
        {
           

           var DS = _menubarRepository.AddMenu(menu);
            if(DS == null)
            {
                return false;
            } 
            return true;
        }

    }
}