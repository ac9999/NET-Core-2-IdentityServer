using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Auth.Api.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class ApiController : Controller
    {
        [Route("text/welcome")]
        [Authorize]
        public IActionResult GetWelcomeText()
        {
            return Content("API Response : Welcome " + User.Identity.Name);
        }

        [Route("user")]
        [Authorize]
        public IActionResult GetUser()
        {
            return Content("API Response : You are logged in as " + User.Identity.Name);
        }
    }
}
