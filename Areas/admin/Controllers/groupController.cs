using System.Data;
using System.Linq;
using System.Web.Mvc;
using SDES___Office_Directory.Code;
using SDES___Office_Directory.Models;

namespace SDES___Office_Directory.Areas.admin.Controllers
{
    [Authorize(Roles = @"SDES\Web-SDES Directory Admin Access")]
    public class groupController : AuthorizeBaseController
    {
        //
        // GET: /admin/group/

        public ActionResult Index()
        {
            var db = new SDES_DirectoryEntities();
            var groups = db.groups.OrderBy(x => x.groupName);
            return View(groups.ToList());
        }

        //
        // GET: /admin/group/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /admin/group/Create

        [HttpPost]
        public ActionResult Create(group addition)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    db.groups.Add(addition);
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
        // GET: /admin/group/Edit/5
 
        public ActionResult Edit(int id)
        {
            var db = new SDES_DirectoryEntities();
            var group = db.groups.Find(id);
            return View(group);
        }

        //
        // POST: /admin/group/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, group edits)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    db.Entry(edits).State = EntityState.Modified;
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
        // GET: /admin/group/Delete/5
 
        public ActionResult Delete(int id)
        {
            var db = new SDES_DirectoryEntities();
            var group = db.groups.Find(id);
            return View(group);
        }

        //
        // POST: /admin/group/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, group deletion)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    var group = db.groups.Find(id);
                    db.Entry(group).State = EntityState.Deleted;
                    db.SaveChanges();
                }
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
