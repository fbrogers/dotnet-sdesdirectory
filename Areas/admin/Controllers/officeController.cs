using System.Data;
using System.Linq;
using System.Web.Mvc;
using SDES___Office_Directory.Code;
using SDES___Office_Directory.Models;

namespace SDES___Office_Directory.Areas.admin.Controllers
{
    public class officeController : Controller
    {
        //
        // GET: /admin/office/

        public ActionResult Index()
        {
            var db = new SDES_DirectoryEntities();
            var offices = db.offices.OrderBy(x => x.officeName);
            return View(offices.ToList());
        }

        //
        // GET: /admin/office/Details/5

        public ActionResult Details(int id)
        {
            var db = new SDES_DirectoryEntities();
            var office = db.offices.Find(id);
            return View(office);
        }

        //
        // GET: /admin/office/Create

        public ActionResult Create()
        {
            ViewBag.groupId = Init.PopulateGroupsDropDownList();
            return View();
        } 

        //
        // POST: /admin/office/Create

        [HttpPost]
        public ActionResult Create(office office)
        {
            try
            {
                using(var db = new SDES_DirectoryEntities())
                {
                    db.offices.Add(office);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /admin/office/Edit/5
 
        public ActionResult Edit(int id)
        {
            var db = new SDES_DirectoryEntities();
            var office = db.offices.Find(id);
            ViewBag.groups = Init.PopulateGroupsDropDownList(id);
            return View(office);
        }

        //
        // POST: /admin/office/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, office office)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    db.Entry(office).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                } 
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /admin/office/Delete/5
 
        public ActionResult Delete(int id)
        {
            var db = new SDES_DirectoryEntities();
            var office = db.offices.Find(id);
            return View(office);
        }

        //
        // POST: /admin/office/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, office office)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    var office1 = db.offices.Find(id);
                    db.Entry(office1).State = EntityState.Deleted;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View(office);
            }
        }
    }
}
