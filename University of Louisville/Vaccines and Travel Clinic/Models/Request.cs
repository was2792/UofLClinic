using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

using System.ComponentModel.DataAnnotations;

namespace Vaccines_and_Travel_Clinic.Models
{
    public class Request
    {
        public int ID { get; set; }
       
        
        [Display(Name = "Patient ID")]
        public int patientNumber { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

       [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime? date { get; set; }

        [DataType(DataType.Time)]
        [Display(Name="Time")]
        public string startTime { get; set; }

        
    }

}