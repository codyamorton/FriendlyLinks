using FriendlyLinks.Models;
using FriendlyLinks.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FriendlyLinks.Controllers
{
    [Authorize]
    public class TeeTimeController : Controller
    {
        // GET: TeeTime
        
        public ActionResult Index()
        {
            var model = new TeeTimeListItem[0];
            return View(model);

        }
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeeTimeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTeeTimeService();

            if (service.CreateTeeTime(model))
            {
                TempData["SaveResult"] = "Your Tee Time was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Tee Time could not be created.");
            return View(model);
        }
        public ActionResult Details(Guid id)
        {
            var svc = CreateTeeTimeService();
            var model = svc.GetTeeTimeById(id);

            return View(model);
        }
        public ActionResult Edit(Guid id)


        {
            var service = CreateTeeTimeService();
            var detail = service.GetTeeTimeById(id);
            var model =
            new TeeTimeEdit
            {
                TeeTimeId = detail.TeeTimeId,
               CourseName = detail.CourseName,
               CourseCity = detail.CourseCity,
               CoursePrice = detail.CoursePrice
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, TeeTimeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TeeTimeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateTeeTimeService();

            if (service.UpdateTeeTime(model))
            {
                TempData["SaveResult"] = "Your Tee Time was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Tee Time could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(Guid id)
        {
            var svc = CreateTeeTimeService();
            var model = svc.GetTeeTimeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTeeTime(Guid id)
        {
            var service = CreateTeeTimeService();

            service.TeeTimeDelete(id);

            TempData["SaveResult"] = "Your TeeTime was deleted";
            return RedirectToAction("Index");
        }


        private TeeTimeServices CreateTeeTimeService()
        {
            //var teeTimeId = Guid.Parse(User.Identity.GetTeeTimeId());
            var service = new TeeTimeServices();
            return service;
        }
    }
}