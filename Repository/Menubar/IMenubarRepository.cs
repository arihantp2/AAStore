using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AAStore.API.Model;

namespace AAStore.API.Repository.Menubar
{
    public interface IMenubarRepository 
    {
        public DataSet GetMenu();
        public DataSet AddMenu(MenubarModel menuBar);
    }
}