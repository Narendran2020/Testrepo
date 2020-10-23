using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.DataTransferObjects.ClinicianSchedule.Response
{
    public class AddClinicianScheduleResponseDto
    {
        public int Id { get; set; }
        public ClinicianLicenseDto ClinicianLicense { get; set; }

        public FacilityDto Facility { get; set; }

        public SlotDto Slot { get; set; }

        public DateTime ScheduleDate { get; set; }
    }

    public sealed class ClinicianLicenseDto
    {
        public string Id { get; set; }

        public string Clinician { get; set; }
    }
    public sealed class SlotDto
    {
        public string Id { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string ConsultationInterval { get; set; }

    }
    public sealed class FacilityDto
    {
        public string Id { get; set; }

        public string Facility { get; set; }
    } 
}

