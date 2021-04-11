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
                                                          iidDoctor = doctor.IIDDOCTOR,
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
        [HttpGet]
        public DoctorCLS RecuperarDoctor(int iidDoctor)
        {
            using (BDDoctorDataContext bd = new BDDoctorDataContext())
            {
                DoctorCLS oDoctorCLS = bd.Doctor.Where(p => p.IIDDOCTOR == iidDoctor)
                    .Select(p => new DoctorCLS
                    {
                        iidDoctor = p.IIDDOCTOR,
                        nombre = p.NOMBRE,
                        apPaterno = p.APPATERNO,
                        apMaterno = p.APMATERNO,
                        email = p.EMAIL,
                        fechaContrato = (DateTime)p.FECHACONTRATO,
                        archivo=p.ARCHIVO,
                        iidSexo=(int)p.IIDSEXO,
                        nombreArchivo=p.NOMBREARCHIVO,
                        sueldo=(decimal)p.SUELDO,
                        telefonoCelular=p.TELEFONOCELULAR,
                        iidClinica=(int)p.IIDCLINICA,
                        iidEspecialidad=(int)p.IIDESPECIALIDAD


                    }

                    ).First();

                return oDoctorCLS;
            }

        }

    }
}
