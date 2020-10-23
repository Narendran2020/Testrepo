using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.Appointment.Request
{
    public sealed class AddAppointmentScheduleRequestDto
    {
        public int FacilityID { get; set; }

        public int ClinicianLicenseID { get; set; }

        //public AddAppointmentRequestDto AppointmentSchedule { get; set; }

    }
}
