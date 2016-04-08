using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolAide2016.Contollers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(string Name, string Password, string returnUrl=null)
        {
            ViewData["ReturnURL"] = returnUrl;
            if(!string.IsNullOrWhiteSpace(Name)&& Name==Password)
            {
                var claims = new List<Claim>
                {
                    new Claim("sub","1232321"),
                    new Claim("Name", "Test"),
                    new Claim("Role", "TestUser")
                };

                var id = new ClaimsIdentity(claims, "password");
                await HttpContext.Authentication.SignInAsync("Cookies", new ClaimsPrincipal(id));
                return new LocalRedirectResult(returnUrl);
            }
            return View();
        }
    }
}
