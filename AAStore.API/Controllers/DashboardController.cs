using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AAStore.API.Model;
using AAStore.API.BusinessLogic.Menubar;
using AAStore.API.BusinessLogic.Category;
using AAStore.API.BusinessLogic.Company;
using AAStore.API.BusinessLogic.User;

namespace AAStore.API.Controllers
{
    [ApiController]     
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {   
        private readonly IMenubarManager _menubarManager;
        private readonly ICategoryManager _categoryManager ;
        private readonly ICompanyManager _companyManager;
        private readonly IUserManager _userManager;

        public DashboardController(IMenubarManager menubarManager,
        ICategoryManager categoryManager,
        ICompanyManager companyManager,
        IUserManager userManager
        )
        {
                _menubarManager = menubarManager;
                _categoryManager = categoryManager;
                _companyManager = companyManager;
                _userManager = userManager;
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
        [Route("GetCategory")]
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

        [HttpGet]
        [Route("CompanyByCategory")]
        public IEnumerable<CompanyModel> GetCompany(int id)
        {
            List<CompanyModel> list = _companyManager.GetCompany(id);
            return list;
        }

        [HttpPost]
        [Route("AddCompany")]
        public IActionResult AddCompany([FromBody]CompanyModel company )
        {
            var message = _companyManager.AddCompany(company);
            return Ok(message);
        }

        [HttpPut]
        [Route("UpdateCompany/{id}")]
        public IActionResult UpdateCompany(int id,[FromBody] CompanyModel company)
        {
            var message = _companyManager.UpdateCompany(id,company);
            return Ok(message);
        }

        [HttpDelete]
        [Route("DeleteCompany/{id}")]
        public IActionResult DeleteCompany(int id)
        {
            var message = _companyManager.DeleteCompany(id);
            return Ok(message);
        }

        [HttpGet]
        [Route("GetAllUsers")]

        public IEnumerable<UserModel> GetUsers()
        {
            List<UserModel> list =_userManager.GetUsers();
            return list;
        }

        [HttpGet]
        [Route("GetUserById/{id}")]

        public IActionResult GetUserById (int id)
        {
            var message = _userManager.GetCategoryById(id);
            return Ok(message);
        }

        [HttpPost]
        [Route("AddUser")]

        public IActionResult AddUser([FromBody]UserModel user)
        {
            var message = _userManager.AddUser(user);
            return Ok(message);
        }

        [HttpPut]
        [Route("UpdateUser/{id}")]

        public IActionResult UpdateUser(int id,[FromBody] UserModel user)
        {
            var message = _userManager.UpdateUser(id,user);
            return Ok(message);
        }

        [HttpDelete]
        [Route("DeleteUser/{id}")]

        public IActionResult DeleteUser(int id)
        {
            var message = _userManager.DeleteUser(id);
            return Ok(message);
        }
    }    
}