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
using Microsoft.AspNetCore.Authorization;


namespace BTLNhom3.Controllers
{
<<<<<<< HEAD
    [Authorize]
=======
>>>>>>> a2d4027baa60a5ba3c7ff7281aa0beb35a1ed462
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

<<<<<<< HEAD
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
=======
>>>>>>> a2d4027baa60a5ba3c7ff7281aa0beb35a1ed462
        [HttpPost]

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


        
        public IActionResult Welcome()
        {
            ViewBag.username = HttpContext.Session.GetString("Username");
            return View("Welcome");
        }

        
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index");
        }


}
}
