using MiPrimeraWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiPrimeraWebAPI.Controllers
{
    public class EspecialidadController : ApiController
    {
        [HttpGet]
        public IEnumerable<EspecialidadCLS> ListarEspecialidad()

        {
            using (BDDoctorDataContext bd = new BDDoctorDataContext())
            {
                IEnumerable<EspecialidadCLS> ListaEspecialidad = (from especialidad in
                                                                   bd.Especialidad
                                                                  where especialidad.BHABILITADO == 1
                                                                  select new EspecialidadCLS
                                                                  {
                                                                      iiEspecialidad = especialidad.IIDESPECIALIDAD,
                                                                      nombreEspecialidad = especialidad.DESCRIPCION

                                                            }).ToList();
                return ListaEspecialidad;
            }
        }

    

        [HttpPut]
        public int EliminarDoctor(int iiDoctor)
        {
            int rpta = 0;
            try
            {
                using (BDDoctorDataContext bd = new BDDoctorDataContext())
                {
                    Doctor oDoctor = bd.Doctor.Where(p => p.IIDDOCTOR == iiDoctor).First();
                    oDoctor.BHABILITADO = 0;
                    bd.SubmitChanges();
                    rpta = 1;
                }
            }
            catch (Exception ex)
            {
                
                rpta = 0;
            }
            return rpta;
        }


    }
}
