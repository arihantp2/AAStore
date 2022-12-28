using AAStore.API.Model;

namespace AAStore.API.BusinessLogic.Category
{
    public interface ICategoryManager 
    {
        List<CategoryModel> GetCategory();
        CategoryModel GetCategoryById(int id); 
        public bool AddCategory(CategoryModel category);
        bool UpdateCategory(int id,CategoryModel category);
        bool DeleteCategory(int id);
      
    }
}