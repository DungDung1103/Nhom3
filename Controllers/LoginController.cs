using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTLNhom3.Models;
using MvcMovie.Data;
using BTLNhom3.Account;

namespace BTLNhom3.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        // private readonly MvcMovieContext _context;

        // public LoginController(MvcMovieContext context)
        // {
        //     _context = context;
        // }

        private Service acountService;
        public LoginController(Service _acountService)
        {
            acountService = _acountService;
        }
        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string Username, string Password)
        {
            var account = acountService.Login(Username, Password);
            if(account !=null)
            {
                HttpContext.Session.SetString("username", Username);
                return RedirectToAction("Welcome");
            }
            else
            {
                ViewBag.mess = "Invalid";
                 return View("Index");
            }
           
        }


         [Route("Welcome")]
        public IActionResult Welcome()
        {
            ViewBag.username = HttpContext.Session.GetString("Username");
            return View("Welcome");
        }

        
         [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index");
        }


}
}
