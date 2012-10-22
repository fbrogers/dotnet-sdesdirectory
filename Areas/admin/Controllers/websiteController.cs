using System.Data;
using System.Linq;
using System.Web.Mvc;
using SDES___Office_Directory.Code;
using SDES___Office_Directory.Models;

namespace SDES___Office_Directory.Areas.admin.Controllers
{
    public class websiteController : Controller
    {
        //
        // GET: /admin/website/

        public ActionResult Index()
        {
            var db = new SDES_DirectoryEntities();
            var sites = db.websites.OrderBy(x => x.office.officeName).ThenBy(x => x.websiteOrder);
            return View(sites.ToList());
        }

        //
        // GET: /admin/website/Create

        public ActionResult Create()
        {
            ViewBag.officeId = Init.PopulateOfficesDropDownList();
            return View();
        }

        public ActionResult CreateFromOffice(int id)
        {
            return View(new website{ officeId = id });
        } 

        //
        // POST: /admin/website/Create

        [HttpPost]
        public ActionResult Create(website site)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    db.websites.Add(site);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult CreateFromOffice(website site)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    db.websites.Add(site);
                    db.SaveChanges();
                }

                return RedirectToAction("Details", "office", new { id = site.officeId });
            }
            catch
            {
                return View(site);
            }
        }        
        //
        // GET: /admin/website/Edit/5

        public ActionResult Edit(int id)
        {
            var db = new SDES_DirectoryEntities();
            var site = db.websites.Find(id);
            ViewBag.offices = Init.PopulateOfficesDropDownList(id);
            return View(site);
        }

        public ActionResult EditFromOffice(int id)
        {
            var db = new SDES_DirectoryEntities();
            var site = db.websites.Find(id);
            return View(site);
        }

        //
        // POST: /admin/website/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, website site)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    db.Entry(site).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult EditFromOffice(int id, website site)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    db.Entry(site).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Details", "office", new { id = site.officeId });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /admin/website/Delete/5

        public ActionResult Delete(int id)
        {
            var db = new SDES_DirectoryEntities();
            var site = db.websites.Find(id);
            return View(site);
        }

        public ActionResult DeleteFromOffice(int id)
        {
            var db = new SDES_DirectoryEntities();
            var site = db.websites.Find(id);
            return View(site);
        }

        //
        // POST: /admin/website/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, website site)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    var website = db.websites.Find(id);
                    db.Entry(website).State = EntityState.Deleted;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteFromOffice(int id, website website)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    var site = db.websites.Find(id);
                    db.Entry(site).State = EntityState.Deleted;
                    db.SaveChanges();
                    return RedirectToAction("Details", "office", new { id = site.officeId });
                }

            }
            catch
            {
                return View();
            }
        }
    }
}
