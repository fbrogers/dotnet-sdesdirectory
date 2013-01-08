using System.Linq;
using System.Text;
using System.Web.Mvc;
using SDES___Office_Directory.Code;
using SDES___Office_Directory.Models;

namespace SDES___Office_Directory.Controllers
{
    public class feedController : Controller
    {
        //
        // GET: /feed/

        public ActionResult Index()
        {
            var db = new SDES_DirectoryEntities();
            var offices = db.offices.OrderBy(x => x.officeName).ToList();

            //init json list
            var json = new FeedViewModel();

            foreach (var office in offices)
            {
                //begin new view model object
                var department = new JsonOffice
                {
                    name = office.officeName,
                    acronym = office.officeAcronym,
                    phone = office.officePhone,
                    fax = office.officeFax,
                    email = office.officeEmail,
                    location =
                    {
                        building = office.officeLocationBuilding,
                        buildingNumber = office.officeLocationBuildingNum,
                        roomNumber = office.officeLocationRoomNum
                    },
                    postOfficeBox = office.officeBox,
                    offersPublicServices = office.offersPublicServices,
                    functionalGroup = office.group.groupName
                };

                //assign websites
                foreach (var website in office.websites.OrderBy(x => x.websiteOrder))
                {
                    var site = new JsonWebsite
                    {
                        name = website.websiteName,
                        uri = website.websiteUri,
                        eventCalendar = website.websiteCal
                    };

                    //add to master list
                    department.websites.Add(site);
                }

                //assign hours
                foreach(var hours in office.hours.OrderBy(x => x.hoursDay))
                {
                    var day = new JsonHours
                    {
                        day = Init.ConvertDaytoText(hours.hoursDay),
                        open = hours.hoursOpen.ToString(),
                        close = hours.hoursClose.ToString()
                    };

                    //add to master list
                    department.hours.Add(day);
                }

                //assign staff
                foreach (var staff in office.staffs.OrderBy(x => x.staffOrder))
                {
                    var member = new JsonStaff
                    {
                        name = staff.staffName,
                        position = staff.staffTitle
                    };

                    //add to master list
                    department.staff.Add(member);
                }

                //assign social networks
                foreach (var social in office.socials)
                {
                    var network = new JsonSocial
                    {
                        name = social.socialName,
                        uri = social.socialUri,
                        uid = social.socialHandle
                    };

                    //add to master list
                    department.socialNetworks.Add(network);
                }

                //assign other locations
                foreach (var locations in office.otherLocations)
                {
                    var other = new JsonOtherLocations
                    {
                        name = locations.otherLocationName,
                        building = locations.otherLocationBuildingName,
                        buildingNumber = locations.otherLocationBuildingNum,
                        roomNumber = locations.otherLocationRoomNum,
                        email = locations.otherLocationEmail,
                        phone = locations.otherLocationPhone,
                        fax = locations.otherLocationFax
                    };

                    //add to master list
                    department.otherLocations.Add(other);
                }

                //add to master list
                json.departments.Add(department);
            }

            //return json
            return Json(json, "application/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }

    }
}
