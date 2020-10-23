using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.ClinicianSchedule.Request
{
    public class UpdateClinicianScheduleRequestDto
    {
        public int ClinicianLicenseID { get; set; }

        public string ScheduleDate { get; set; }

        public int SlotID { get; set; }

        public int FacilityID { get; set; }

        public int ModifiedBy { get; set; }
    }
}
