using System.Data;
using System.Linq;
using System.Web.Mvc;
using SDES___Office_Directory.Code;
using SDES___Office_Directory.Models;

namespace SDES___Office_Directory.Areas.admin.Controllers
{
    public class staffController : AuthorizeBaseController
    {
        //
        // GET: /admin/staff/

        public ActionResult Index()
        {
            var db = new SDES_DirectoryEntities();
            var members = db.staffs.OrderBy(x => x.staffOrder);
            return View(members.ToList());
        }

        //
        // GET: /admin/staff/Create

        public ActionResult Create(int id)
        {
            return View(new staff { officeId = id });
        } 

        //
        // POST: /admin/staff/Create

        [HttpPost]
        public ActionResult Create(staff member)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    db.staffs.Add(member);
                    db.SaveChanges();
                }

                return RedirectToAction("Details", "office", new { id = member.officeId });
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /admin/staff/Edit/5
 
        public ActionResult Edit(int id)
        {
            var db = new SDES_DirectoryEntities();
            var member = db.staffs.Find(id);
            return View(member);
        }

        //
        // POST: /admin/staff/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, staff member)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    db.Entry(member).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Details", "office", new { id = member.officeId });
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /admin/staff/Delete/5
 
        public ActionResult Delete(int id)
        {
            var db = new SDES_DirectoryEntities();
            var member = db.staffs.Find(id);
            return View(member);
        }

        //
        // POST: /admin/staff/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, staff memberpost)
        {
            try
            {
                using (var db = new SDES_DirectoryEntities())
                {
                    var member = db.staffs.Find(id);
                    db.Entry(member).State = EntityState.Deleted;
                    db.SaveChanges();
                    return RedirectToAction("Details", "office", new { id = member.officeId });
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
