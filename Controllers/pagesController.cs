using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDES___Office_Directory.Models;

namespace SDES___Office_Directory.Controllers
{
    public class pagesController : Controller
    {
        //
        // GET: /pages/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /pages/Directory/

        public ActionResult Directory()
        {
            var db = new SDES_DirectoryEntities();
            var offices = db.offices.OrderBy(x => x.officeName);
            return View(offices.ToList());
        }
    }
}
