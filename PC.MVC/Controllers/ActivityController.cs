using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PC.MVC.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult Show()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}