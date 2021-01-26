using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetVet2.Domain.Entities;

namespace NetVet2.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        /// <summary>
        /// Returns active appointments.
        /// </summary>
        IQueryable<Appointment> GetAppointments(bool includeDeleted = false);
    }
}
