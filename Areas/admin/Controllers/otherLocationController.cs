using System.Data;
using System.Linq;
using System.Web.Mvc;
using SDES___Office_Directory.Code;
using SDES___Office_Directory.Models;

namespace SDES___Office_Directory.Areas.admin.Controllers
{
    public class otherLocationController : Controller
    {
        //
        // GET: /admin/otherLocation/

        public ActionResult Index()
        {
            var db = new SDES_DirectoryEntities();
            var locations = db.otherLocations.OrderBy(x => x.office.officeName);
            return View(locations.ToList());
        }

        //
        // GET: /admin/otherLocation/Create

        public ActionResult Create()
        {
            ViewBag.officeId = Init.PopulateOfficesDropDownList();
            return View();
        } 

        //
        // POST: /admin/otherLocation/Create

        [HttpPost]
        public ActionResult Create(otherLocation location)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    db.otherLocations.Add(location);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.officeId = Init.PopulateOfficesDropDownList();
                return View(location);
            }
        }
        
        //
        // GET: /admin/otherLocation/Edit/5
 
        public ActionResult Edit(int id)
        {
            var db = new SDES_DirectoryEntities();
            var location = db.otherLocations.Find(id);
            ViewBag.offices = Init.PopulateOfficesDropDownList(id);
            return View(location);
        }

        //
        // POST: /admin/otherLocation/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, otherLocation location)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    db.Entry(location).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(location);
            }
        }

        //
        // GET: /admin/otherLocation/Delete/5
 
        public ActionResult Delete(int id)
        {
            var db = new SDES_DirectoryEntities();
            var location = db.otherLocations.Find(id);
            return View(location);
        }

        //
        // POST: /admin/otherLocation/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, otherLocation location)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    var specific = db.otherLocations.Find(id);
                    db.Entry(specific).State = EntityState.Deleted;
                    db.SaveChanges();
                }
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View(location);
            }
        }
    }
}
