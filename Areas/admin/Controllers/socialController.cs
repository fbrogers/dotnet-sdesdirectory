using System.Data;
using System.Web.Mvc;
using SDES___Office_Directory.Models;

namespace SDES___Office_Directory.Areas.admin.Controllers
{
    public class socialController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "office");
        }

        public ActionResult Create(int id)
        {
            return View(new social { officeId = id });
        } 

        [HttpPost]
        public ActionResult Create(social handle)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    db.socials.Add(handle);
                    db.SaveChanges();
                }

                return RedirectToAction("Details", "office", new { id = handle.officeId });
            }
            catch
            {
                return View();
            }
        }
 
        public ActionResult Edit(int id)
        {
            var db = new SDES_DirectoryEntities();
            var handle = db.socials.Find(id);
            return View(handle);
        }

        [HttpPost]
        public ActionResult Edit(int id, social handle)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    db.Entry(handle).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Details", "office", new { id = handle.officeId });
            }
            catch
            {
                return View();
            }
        }
 
        public ActionResult Delete(int id)
        {
            var db = new SDES_DirectoryEntities();
            var handle = db.socials.Find(id);
            return View(handle);
        }

        [HttpPost]
        public ActionResult Delete(int id, social handles)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    var handle = db.socials.Find(id);
                    db.Entry(handle).State = EntityState.Deleted;
                    db.SaveChanges();
                    return RedirectToAction("Details", "office", new { id = handle.officeId });
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
