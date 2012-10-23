using System.Web.Mvc;

namespace SDES___Office_Directory.Code
{
    [Authorize(Roles = @"SDES\Web-SDES Directory Admin Access")]
    public abstract class AuthorizeBaseController : Controller
    {

    }
}