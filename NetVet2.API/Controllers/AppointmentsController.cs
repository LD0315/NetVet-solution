using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetVet2.API.Models;
using NetVet2.Domain.Entities;
using NetVet2.Domain.Repositories;

namespace NetVet2.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {

        private readonly IAppointmentRepository appointmentRepository;


        public AppointmentsController()
        {
            this.appointmentRepository = new MockAppointmentRepository();
        }




        [HttpGet]
        [Route("get_all")]
        public ActionResult<List<AppointmentModel>> getAppointments(string search)
        {
            var result = new List<AppointmentModel>();
            try
            {




                IOrderedEnumerable<Appointment> query;
                DateTime date;
                if (search == null)
                {
                    query = this.appointmentRepository
                    .GetAppointments()
                    .ToList()
                    .OrderBy(x => x.AppointmentDateTime);
                }
                else if (DateTime.TryParse(search, out date))
                {
                    query = this.appointmentRepository
                    .GetAppointments()
                    .Where(x => x.AppointmentDateTime.Date == date.Date)
                    .ToList()
                    .OrderBy(x => x.AppointmentDateTime);
                }
                else
                {
                    query = this.appointmentRepository
                    .GetAppointments()
                    .Where(x => x.Pet.Name.ToLower() == search.ToLower() || x.Pet.Owner.FirstName.ToLower() == search.ToLower()
                    || x.Pet.Owner.LastName.ToLower() == search.ToLower() ||
                    x.Pet.Owner.FirstName.ToLower() + " " + x.Pet.Owner.LastName.ToLower() == search.ToLower())
                    .ToList()
                    .OrderBy(x => x.AppointmentDateTime);
                }

                
                foreach (var appointment in query)
                {
                    result.Add(new AppointmentModel(appointment));
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(result);
        }

    }
}