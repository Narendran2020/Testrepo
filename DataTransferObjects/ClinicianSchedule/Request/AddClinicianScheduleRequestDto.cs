using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.ClinicianSchedule.Request
{
    public class AddClinicianScheduleRequestDto
    {
        public int ClinicianLicenseID { get; set; }

        public int ScheduledFor { get; set; }

        public DateTime? ScheduleDate { get; set; }

        public ScheduleDateObj ScheduleDates { get; set; }

        public IEnumerable<int> SlotId { get; set; }

        public int FacilityID { get; set; }

        public int CreatedBy { get; set; }
    }
    public sealed class ScheduleDateObj
    {
        public DateTime Begin { get; set; }

        public DateTime End { get; set; }
    }
}
