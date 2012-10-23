using System.Configuration;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using SDES___Office_Directory.Code;
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
        // GET: /pages/Contact

        public ActionResult Contact()
        {
            var db = new SDES_DirectoryEntities();
            var sdesit = db.offices.Single(x => x.officeAcronym == "it");
            return View(sdesit);
        }

        //
        // GET: /pages/Directory

        public ActionResult Directory()
        {
            var db = new SDES_DirectoryEntities();
            var offices = db.offices.OrderBy(x => x.officeName);
            return View(offices.ToList());
        }

        //
        // GET: /pages/Report

        public ActionResult Report()
        {
            return View(new ReportFormViewModel());
        }

        //
        // POST: /pages/Report

        [HttpPost]
        public ActionResult Report(ReportFormViewModel submission)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    //set up email vars
                    const string subject = "SDES Directory | Reporting Form";
                    var to = ConfigurationManager.AppSettings["developerEmail"];
                    var from = submission.email;
                    var body = string.Join("<br />", "Name: " + submission.name, "Phone: " + submission.phone,
                                           "Office: " + submission.office);
                    body = body + "<p>Comment:<br />" + submission.comment + "</p>";

                    //send an email
                    WebMail.SmtpServer = ConfigurationManager.AppSettings["smtpServer"];
                    WebMail.Send(to, subject, body, from);

                    //redirect to thanks page
                    return RedirectToAction("Thanks");
                }
                catch
                {
                    return View(submission);
                }

            }

            return View(submission);
        }

        //
        // GET: /pages/Thanks

        public ActionResult Thanks()
        {
            return View();
        }
    }
}
