using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AAStore.API.Model;
using AAStore.API.BusinessLogic.Menubar;
using AAStore.API.BusinessLogic.Category;

namespace AAStore.API.Controllers
{
    [ApiController]     
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {   
        private readonly IMenubarManager _menubarManager;
        private readonly ICategoryManager _categoryManager ;

        public DashboardController(IMenubarManager menubarManager,ICategoryManager categoryManager)
        {
            _menubarManager = menubarManager;
            _categoryManager = categoryManager;
        }

        [HttpGet]
        [Route("Menubar")]
        public IEnumerable<MenubarModel> GetMenu()
        {
            List<MenubarModel> list = _menubarManager.GetMenu();
            return list;
        }

        [HttpPost]
        [Route("AddMenu")]
        public IActionResult AddMenu([FromBody]MenubarModel menu )
        {
            var message = _menubarManager.AddMenu(menu);
            return Ok(message);
        }

        [HttpGet]
        [Route("Categories")]
        public IEnumerable<CategoryModel> GetCategory()
        {          
            List<CategoryModel> list = _categoryManager.GetCategory();
            return list;           
        }

        [HttpGet]
        [Route("Category/{id}")]

        public IActionResult GetCategoryById(int id)
        {
            var list = _categoryManager.GetCategoryById(id);
            return Ok(list);
        }

        [HttpPost]
        [Route("AddCategory")]
        public IActionResult AddCategory([FromBody]CategoryModel category)
        {
            var message = _categoryManager.AddCategory(category);
            return Ok(message);
        }

        [HttpPut]
        [Route("UpdateCategory/{id}")]
        public IActionResult UpdateCategory(int id,[FromBody]CategoryModel category)
        {
            var message = _categoryManager.UpdateCategory(id,category);
            return Ok(message);
        }

        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var message = _categoryManager.DeleteCategory(id);
            return Ok(message);
        }
    }
}