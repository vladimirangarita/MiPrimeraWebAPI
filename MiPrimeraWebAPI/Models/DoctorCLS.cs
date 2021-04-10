using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiPrimeraWebAPI.Models
{
    public class DoctorCLS
    {
        public int iiDoctor { get; set; }
        public string nombreCompleto { get; set; }
        public string nombreClinica { get; set; }

        public string nombreEspecialidad { get; set; }
        public string email { get; set; }

        public DateTime fechaContrato { get; set; }
    }
}