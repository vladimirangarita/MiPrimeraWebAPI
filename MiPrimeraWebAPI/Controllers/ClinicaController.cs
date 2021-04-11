using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MiPrimeraWebAPI.Models;
namespace MiPrimeraWebAPI.Controllers
{
    public class ClinicaController : ApiController
    {
        [HttpGet]
        public IEnumerable<ClinicaCLS> ListarClinicas()

        {
            using (BDDoctorDataContext bd = new BDDoctorDataContext())
            {
                IEnumerable<ClinicaCLS> ListaClinica = (from clinica in
                                                                   bd.Clinica
                                                                  where clinica.BHABILITADO == 1
                                                                  select new ClinicaCLS
                                                                  {
                                                                      iidClinica = clinica.IIDCLINICA,
                                                                      nombreClinica = clinica.NOMBRE

                                                                  }).ToList();
                return ListaClinica;
            }
        }


    }
}
