using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using SDES___Office_Directory.Models;

namespace SDES___Office_Directory.Code
{
    public static class Init
    {
        public static IEnumerable<SelectListItem> PopulateGroupsDropDownList(int? id = null)
        {
            var db = new SDES_DirectoryEntities();
            var groups = db.groups.OrderBy(x => x.groupName).ToList();
            var list = groups.Select(x => new SelectListItem
            {
                Text = x.groupName,
                Value = x.groupId.ToString(CultureInfo.InvariantCulture),
                Selected = (x.groupId == id)
            }).ToList();
            return list;
        }

        public static IEnumerable<SelectListItem> PopulateOfficesDropDownList(int? id = null)
        {
            var db = new SDES_DirectoryEntities();
            var groups = db.offices.OrderBy(x => x.officeName).ToList();
            var list = groups.Select(x => new SelectListItem
            {
                Text = x.officeName,
                Value = x.officeId.ToString(CultureInfo.InvariantCulture),
                Selected = (x.officeId == id)
            }).ToList();
            return list;
        }

        public static IEnumerable<SelectListItem> PopulateOfficesDropDownListStatic(string id = null)
        {
            var db = new SDES_DirectoryEntities();
            var groups = db.offices.OrderBy(x => x.officeName).ToList();
            var list = groups.Select(x => new SelectListItem
            {
                Text = x.officeName,
                Value = x.officeName,
                Selected = (x.officeName == id)
            }).ToList();
            return list;
        }

        public static string ConvertDaytoText(int hoursDay)
        {
            var output = string.Empty;

            switch (hoursDay)
            {
                case 0:
                    output = "Monday";
                    break;
                case 1:
                    output = "Tuesday";
                    break;
                case 2:
                    output = "Wednesday";
                    break;
                case 3:
                    output = "Thursday";
                    break;
                case 4:
                    output = "Friday";
                    break;
                case 5:
                    output = "Saturday";
                    break;
                case 6:
                    output = "Sunday";
                    break;
            }

            return output;
        }
    }
}