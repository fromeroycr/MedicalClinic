using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalClinicWeb.Models
{
    public class PatientModelViewModel
    {
        public int PatientID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}