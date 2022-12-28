using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using AAStore.API.Model;
using AAStore.API.Repository.Category;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AAStore.API.BusinessLogic.Category
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IConfiguration _configuration;

        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(IConfiguration configuration,ICategoryRepository categoryRepository)
        {
            _configuration = configuration;
            _categoryRepository = categoryRepository;
        }

        public List<CategoryModel> GetCategory()
        {
            List<CategoryModel> cm = new List<CategoryModel>();
            DataSet DS = new DataSet();

            DS = _categoryRepository.GetCategory();
            if (DS!= null)
            {
                DataTable dt = DS.Tables[0];
                if(dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        CategoryModel data = new CategoryModel();
                        data.CategoryId =  Convert.ToInt32(dr["CategoryId"].ToString());
                        data.CategoryName=dr["CategoryName"].ToString();
                        cm.Add(data);
                    }
                }
            }
            return cm;
        }

        public CategoryModel GetCategoryById(int id)
        {
            DataSet DS = new DataSet();
            CategoryModel cm = new CategoryModel();
            
            DS = _categoryRepository.GetCategoryById(id);
            if (DS!=null)
            {
                DataTable dt = DS.Tables[0];
                if(dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        //data.CategoryId =  Convert.ToInt32(dr["CategoryId"].ToString());
                        cm.CategoryName=dr["CategoryName"].ToString();
                    }
                }
            }
            return cm;
        }
        public bool AddCategory(CategoryModel category)
        {
            var DS = _categoryRepository.AddCategory(category);
            if (DS==null)
            {
                return false;
            }
            return true;
        }

        public bool UpdateCategory(int id,CategoryModel category)
        {
            var DS = _categoryRepository.UpdateCategory(id,category);
            if(DS == null)
            {
                return false;
            }
            return true;
        }

        public bool DeleteCategory(int id)
        {
            var DS = _categoryRepository.DeleteCategory(id);
            if(DS==null)
            {
                return false;
            }
            return true;
        }
    }
}
