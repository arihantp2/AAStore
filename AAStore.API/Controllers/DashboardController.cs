using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AAStore.API.Model;
using AAStore.API.BusinessLogic.Menubar;

namespace AAStore.API.Controllers
{
    [ApiController]     
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {   
        private readonly IMenubarManager _menubarManager;

        public DashboardController(IMenubarManager menubarManager)
        {
            _menubarManager = menubarManager;
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
    }
}