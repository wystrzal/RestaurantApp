using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Menu.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Menu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IRepositoryWrapper repositoryWrapper;

        public MenuController(IRepositoryWrapper repositoryWrapper)
        {
            this.repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var menu = await repositoryWrapper.MenuRepository.GetByCondition(x => x.MenuTypeId == 1);

            return Ok(menu);
        }








    }
}