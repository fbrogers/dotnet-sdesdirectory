using System.Web.Mvc;
using SDES___Office_Directory.Code;

namespace SDES___Office_Directory.Areas.admin.Controllers
{
    public class pagesController : AuthorizeBaseController
    {
        //
        // GET: /admin/pages/

        public ActionResult Index()
        {
            return View();
        }
    }
}
