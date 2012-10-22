using System.Data;
using System.Linq;
using System.Web.Mvc;
using SDES___Office_Directory.Models;

namespace SDES___Office_Directory.Areas.admin.Controllers
{
    public class hoursController : Controller
    {
        //
        // GET: /pages/

        public ActionResult Index()
        {
            return RedirectToAction("Index", "office");
        }

        //
        // GET: /admin/hours/Create

        public ActionResult Create(int id)
        {
            var hour = new hour {officeId = id};
            return View(hour);
        } 

        //
        // POST: /admin/hours/Create

        [HttpPost]
        public ActionResult Create(int officeId, hour day)
        {
            try
            {
                using(var db = new SDES_DirectoryEntities())
                {
                    db.hours.Add(day);
                    db.SaveChanges();
                }

                return RedirectToAction("Details", "office", new { id = officeId });
            }
            catch
            {
                return View(day);
            }
        }
        
        //
        // GET: /admin/hours/Edit/5
 
        public ActionResult Edit(int id)
        {
            var db = new SDES_DirectoryEntities();
            var day = db.hours.Find(id);
            return View(day);
        }

        //
        // POST: /admin/hours/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, hour day)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    db.Entry(day).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Details", "office", new { id = day.officeId });
            }
            catch
            {
                return View(day);
            }
        }

        //
        // GET: /admin/hours/Delete/5
 
        public ActionResult Delete(int id)
        {
            var db = new SDES_DirectoryEntities();
            var day = db.hours.Find(id);
            return View(day);
        }

        //
        // POST: /admin/hours/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, hour day)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    var hours = db.hours.Find(id);
                    db.Entry(hours).State = EntityState.Deleted;
                    db.SaveChanges();
                    return RedirectToAction("Details", "office", new { id = hours.officeId });
                }
            }
            catch
            {
                return View(day);
            }
        }
    }
}
