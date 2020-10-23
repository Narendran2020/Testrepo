using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.ClinicianSchedule.Response
{
    public class UpdateClinicianScheduleResponseDto
    {
        public int Id { get; set; }

        public ClinicianLicenseDto ClinicianLicense { get; set; }

        public FacilityDto Facility { get; set; }

        public SlotDto Slot { get; set; }

        public DateTime ScheduleDate { get; set; }
    }
}
