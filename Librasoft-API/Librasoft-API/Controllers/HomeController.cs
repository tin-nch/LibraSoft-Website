﻿using Microsoft.AspNetCore.Mvc;

namespace Librasoft_API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
