﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kd_aspmvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return PartialView();
        }

        public ActionResult Contact()
        {
            return PartialView();
        }
        public ActionResult ShoppingCart()
        {
            return PartialView();
        }
    }
}