using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SDES___Office_Directory.Code
{
    public class ReportFormViewModel
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string phone { get; set; }

        [Required]
        public string office { get; set; }
        public IEnumerable<SelectListItem> officeList { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string comment { get; set; }

        //constructor
        public ReportFormViewModel()
        {
            officeList = Init.PopulateOfficesDropDownListStatic();
        }
    }


}