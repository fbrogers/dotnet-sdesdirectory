using System.Collections.Generic;

namespace SDES___Office_Directory.Code
{
    public class FeedViewModel
    {
        public List<JsonOffice> departments { get; set; }

        public FeedViewModel()
        {
            departments = new List<JsonOffice>();
        }
    }

    public class JsonOffice
    {
        public string name { get; set; }
        public string acronym { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public int? postOfficeBox { get; set; }
        public bool offersPublicServices { get; set; }
        public string functionalGroup { get; set; }

        public JsonLocation location;

        public List<JsonWebsite> websites { get; set; }
        public List<JsonHours> hours { get; set; }
        public List<JsonStaff> staff { get; set; }
        public List<JsonSocial> socialNetworks { get; set; }
        public List<JsonOtherLocations> otherLocations { get; set; } 

        public JsonOffice()
        {
            websites = new List<JsonWebsite>();
            hours = new List<JsonHours>();
            location = new JsonLocation();
            staff = new List<JsonStaff>();
            socialNetworks = new List<JsonSocial>();
            otherLocations = new List<JsonOtherLocations>();
        }
    }

    public class JsonLocation
    {
        public string building { get; set; }
        public string buildingNumber { get; set; }
        public string roomNumber { get; set; }
    }

    public class JsonWebsite
    {
        public string name { get; set; }
        public string uri { get; set; }
        public int? eventCalendar { get; set; }
    }

    public class JsonHours
    {
        public string day { get; set; }
        public string open { get; set; }
        public string close { get; set; }
    }

    public class JsonStaff
    {
        public string name { get; set; }
        public string position { get; set; }
    }

    public class JsonSocial
    {
        public string name { get; set; }
        public string uri { get; set; }
        public string uid { get; set; }
    }

    public class JsonOtherLocations
    {
        public string name { get; set; }
        public string building { get; set; }
        public string buildingNumber { get; set; }
        public string roomNumber { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
    }
}