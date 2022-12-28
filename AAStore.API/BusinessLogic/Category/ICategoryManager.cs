using AAStore.API.Model;

namespace AAStore.API.BusinessLogic.Category
{
    public interface ICategoryManager 
    {
        List<CategoryModel> GetCategory();
        List<CategoryModel> GetCategoryById(int id); 
        public bool AddCategory(CategoryModel category);
      
    }
}