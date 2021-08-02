using FriendlyLinks.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FriendlyLinks.Controllers
{
    public class GolfersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Golfers
        public ActionResult Index()
        {
            return View(db.Golfer.ToList());
        }

        // GET: Golfers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Golfer golfer = db.Golfer.Find(id);
            if (golfer == null)
            {
                return HttpNotFound();
            }
            return View(golfer);
        }

        // GET: Golfers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Golfers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GolferId,FirstName,LastName,Email")] Golfer golfer)
        {
            if (ModelState.IsValid)
            {
                db.Golfer.Add(golfer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(golfer);
        }

        // GET: Golfers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Golfer golfer = db.Golfer.Find(id);
            if (golfer == null)
            {
                return HttpNotFound();
            }
            return View(golfer);
        }

        // POST: Golfers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GolferId,FirstName,LastName,Email")] Golfer golfer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(golfer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(golfer);
        }

        // GET: Golfers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Golfer golfer = db.Golfer.Find(id);
            if (golfer == null)
            {
                return HttpNotFound();
            }
            return View(golfer);
        }

        // POST: Golfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Golfer golfer = db.Golfer.Find(id);
            db.Golfer.Remove(golfer);
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