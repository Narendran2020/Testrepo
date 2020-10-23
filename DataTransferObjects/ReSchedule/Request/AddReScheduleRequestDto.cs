using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.ReSchedule.Request
{
    public class AddReScheduleRequestDto
    {
        public int ID { get; set; }

        public int AppointmentID{ get; set; }

        public int FacilityID { get; set; }

        public int ClinicianLicenseID { get; set; }

        public DateTime RescheduledDate { get; set; }

        public string ReScheduleSlot { get; set; }

        public string ReScheduleReason { get; set; }

        public int ModifiedBy { get; set; }

        public int ExistingSlotID { get; set; }

        public int NewSlotID { get; set; }
    }
}
