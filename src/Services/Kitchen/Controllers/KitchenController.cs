using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers
{
    [Authorize(Policy = "Worker")]
    [Route("api/[controller]")]
    [ApiController]
    public class KitchenController : ControllerBase
    {
    }
}