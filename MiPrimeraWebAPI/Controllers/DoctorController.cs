using MiPrimeraWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Cors;
using System.Web.Http;

namespace MiPrimeraWebAPI.Controllers
{
    [EnableCors(headers: "*", origins: "*", methods: "*")]
    public class DoctorController : ApiController
    {
        //localhost/api/Doctor
        [HttpGet]
        public IEnumerable<DoctorCLS> ListarDoctor()
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
        //localhost/api/Doctor
        [HttpPost]
        public int AgregarDoctor([FromBody]Doctor oDoctor)
        {
            int rpta = 0;
            try
            {
                using (BDDoctorDataContext bd=new BDDoctorDataContext())
                {
                    if (oDoctor.IIDDOCTOR==0)
                    {
                        bd.Doctor.InsertOnSubmit(oDoctor);
                        bd.SubmitChanges();
                        rpta = 1;
                    }
                    else
                    {
                        Doctor oDoctorObjeto = bd.Doctor.Where(p => p.IIDDOCTOR == oDoctor.IIDDOCTOR).First();
                        oDoctorObjeto.NOMBRE = oDoctor.NOMBRE;
                        oDoctorObjeto.APPATERNO = oDoctor.APPATERNO;
                        oDoctorObjeto.APMATERNO = oDoctor.APMATERNO;
                        oDoctorObjeto.IIDCLINICA = oDoctor.IIDCLINICA;
                        oDoctorObjeto.IIDESPECIALIDAD = oDoctor.IIDESPECIALIDAD;
                        if (oDoctor.ARCHIVO!=null && oDoctor.NOMBREARCHIVO!="")
                        {
                            oDoctorObjeto.NOMBREARCHIVO = oDoctor.NOMBREARCHIVO;
                            oDoctorObjeto.ARCHIVO = oDoctor.ARCHIVO;
                        }
                        oDoctorObjeto.EMAIL = oDoctor.EMAIL;
                        oDoctorObjeto.TELEFONOCELULAR = oDoctor.TELEFONOCELULAR;
                        oDoctorObjeto.IIDSEXO = oDoctor.IIDSEXO;
                        oDoctorObjeto.SUELDO = oDoctor.SUELDO;
                        oDoctorObjeto.FECHACONTRATO = oDoctor.FECHACONTRATO;
                        bd.SubmitChanges();
                        rpta = 1;

                    }
                }
            }
            catch (Exception ex)
            {

                rpta=0;
            }

            return rpta;

        }
        //localhost/api/Doctor/?iidD
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
