//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SDES___Office_Directory.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class hour
    {
        public int hoursId { get; set; }
        public int officeId { get; set; }
        public byte hoursDay { get; set; }
        public Nullable<System.TimeSpan> hoursOpen { get; set; }
        public Nullable<System.TimeSpan> hoursClose { get; set; }
    
        public virtual office office { get; set; }
    }
}