using FriendlyLinks.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FriendlyLinks.Controllers
{
    public class TeeTimesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TeeTimes
        public ActionResult Index()
        {
            var teeTime = db.TeeTime.Include(t => t.GolfCourse);
            return View(teeTime.ToList());
        }

        // GET: TeeTimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeeTime teeTime = db.TeeTime.Find(id);
            if (teeTime == null)
            {
                return HttpNotFound();
            }
            return View(teeTime);
        }

        // GET: TeeTimes/Create
        public ActionResult Create()
        {
            ViewBag.GolfCourseId = new SelectList(db.GolfCourse, "CourseId", "CourseName");
            return View();
        }

        // POST: TeeTimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeeTimeId,CoursePrice,TeeOffTime,GolfCourseId")] TeeTime teeTime)
        {
            if (ModelState.IsValid)
            {
                db.TeeTime.Add(teeTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GolfCourseId = new SelectList(db.GolfCourse, "CourseId", "CourseName", teeTime.GolfCourseId);
            return View(teeTime);
        }

        // GET: TeeTimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeeTime teeTime = db.TeeTime.Find(id);
            if (teeTime == null)
            {
                return HttpNotFound();
            }
            ViewBag.GolfCourseId = new SelectList(db.GolfCourse, "CourseId", "CourseName", teeTime.GolfCourseId);
            return View(teeTime);
        }

        // POST: TeeTimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeeTimeId,CoursePrice,TeeOffTime,GolfCourseId")] TeeTime teeTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teeTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GolfCourseId = new SelectList(db.GolfCourse, "CourseId", "CourseName", teeTime.GolfCourseId);
            return View(teeTime);
        }

        // GET: TeeTimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeeTime teeTime = db.TeeTime.Find(id);
            if (teeTime == null)
            {
                return HttpNotFound();
            }
            return View(teeTime);
        }

        // POST: TeeTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeeTime teeTime = db.TeeTime.Find(id);
            db.TeeTime.Remove(teeTime);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}