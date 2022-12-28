using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AAStore.API.Model;
using AAStore.API.BusinessLogic.Menubar;
using AAStore.API.BusinessLogic.Company;

namespace AAStore.API.Controllers
{
    [ApiController]     
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {   
        private readonly IMenubarManager _menubarManager;
        private readonly ICompanyManager _companyManager;

        public DashboardController(IMenubarManager menubarManager, ICompanyManager companyManager)
        {
            _menubarManager = menubarManager;
            _companyManager = companyManager;
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
    }
}