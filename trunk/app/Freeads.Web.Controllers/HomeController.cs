﻿using System.Web.Mvc;

namespace Freeads.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
