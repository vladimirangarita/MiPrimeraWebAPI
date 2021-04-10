using MiPrimeraWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiPrimeraWebAPI.Controllers
{
    public class DoctorController : ApiController
    {
        [HttpGet]
        public IEnumerable<DoctorCLS>ListarDoctor()
        {

            using (BDDoctorDataContext bd = new BDDoctorDataContext())
            {
                IEnumerable<DoctorCLS> ListaDoctor = (from doctor in bd.Doctor
                                                      join clinica in bd.Clinica
                                                      on doctor.IIDCLINICA equals
                                                      clinica.IIDCLINICA
                                                      join especialidad in bd.Especialidad
                                                      on doctor.IIDESPECIALIDAD equals
                                                      especialidad.IIDESPECIALIDAD
                                                      where doctor.BHABILITADO == 1
                                                      select new DoctorCLS

                                                      {
                                                          iiDoctor = doctor.IIDDOCTOR,
                                                          nombreClinica = clinica.NOMBRE,
                                                          nombreEspecialidad = especialidad.NOMBRE,
                                                          email = doctor.EMAIL,
                                                          fechaContrato = (DateTime)doctor.FECHACONTRATO,
                                                          nombreCompleto = doctor.NOMBRE + " " + doctor.APPATERNO
                                                          + " " + doctor.APMATERNO
                                                      }).ToList();


                return ListaDoctor;
            }
            }

    }
}
