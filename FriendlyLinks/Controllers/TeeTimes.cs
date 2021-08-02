using FriendlyLinks.Data;
using FriendlyLinks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FriendlyLinks.Controllers
{
    [Authorize]
    public class TeeTimes : Controller
    {
        // GET: TeeTime
        public ActionResult Index()
        {
            var model = new TeeTimes[0];
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (TeeTimeCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}