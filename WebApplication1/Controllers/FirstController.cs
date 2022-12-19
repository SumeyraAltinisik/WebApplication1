﻿using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class FirstController : Controller
    {
        public string Index()
        {
            return "Hello World";
        }
        public IActionResult Hello()
        {
            ViewBag.Selam = "Naber";
            return View();
        }
    }
}