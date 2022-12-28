using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AAStore.API.Model;

namespace AAStore.API.Repository.Category
{
    public interface ICategoryRepository 
    {
        DataSet GetCategory();
        DataSet GetCategoryById(int id);
        DataSet AddCategory(CategoryModel category);
    }
}