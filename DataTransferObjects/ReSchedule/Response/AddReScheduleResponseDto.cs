using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.ReSchedule.Response
{
    public class AddReScheduleResponseDto
    {
        public int ID { get; set; }

        public int AppointmentID { get; set; }

        public int FacilityID { get; set; }

        public int ClinicianLicenseID { get; set; }

        public DateTime RescheduledDate { get; set; }

        public TimeSpan ReScheduleSlot { get; set; }

        public string ReScheduleReason { get; set; }
    }
}
