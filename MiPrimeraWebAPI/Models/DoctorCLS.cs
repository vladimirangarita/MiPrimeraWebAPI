﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiPrimeraWebAPI.Models
{
    public class DoctorCLS
    {
        public int iidDoctor { get; set; }
        public string nombreCompleto { get; set; }
        public string nombreClinica { get; set; }

        public string nombreEspecialidad { get; set; }
        public string email { get; set; }

        public DateTime fechaContrato { get; set; }


        public string nombre { get; set; }

        public string apPaterno { get; set; }
        public string apMaterno { get; set; }

        public string archivo { get; set; }

        public string nombreArchivo { get; set; }

        public int iidSexo { get; set; }

        public string telefonoCelular { get; set; }

        public decimal sueldo { get; set; }

        public int iidClinica { get; set; }

        public int iidEspecialidad { get; set; }
    }
}