using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.ClinicianSchedule.Request
{
    public sealed class SearchClinicianScheduleDto
    {
        public int? ClinicianLicenseID { get; set; }

        public int? FacilityID { get; set; }

        public ScheduleDateObj ScheduleDates { get; set; }

        public sealed class ScheduleDateObj
        {
            public DateTime? Begin { get; set; }

            public DateTime? End { get; set; }
        }
    }
}
