using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.Appointment.Response
{
    public sealed class AppointmentScheduleResponseDto
    {
        public int Id { get; set; }

        public string FacilityID { get; set; }

        public int ClinicianLicenseID { get; set; }
    }
}
